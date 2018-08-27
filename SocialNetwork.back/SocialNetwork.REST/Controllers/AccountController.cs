using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using SocialNetwork.DL.DM;
using SocialNetwork.Rest.Helpers;
using SocialNetwork.Rest.Models.Request;
using SocialNetwork.Rest.Models.Response;
using SocialNetwork.Rest.Services.JWT;

namespace SocialNetwork.Rest.Controllers
{
    public class AccountController : BaseController
    {
        [HttpPost]
        [Route("signin")]
        public async Task<IActionResult> SignIn([FromBody] SessionRequest model)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);
            var jwt = default(JWTService);

            try
            {
                if (!ModelState.IsValid)
                {
                    response = BadRequest(new ErrorResponse(ConstantsResponse.ERROR_HTTP_400, ModelState));
                }
                else
                {
                    context = new SocialNetworkDbContext();
                    jwt = new JWTService();

                    var projection = Builders<User>.Projection.Exclude("description").Exclude("joindate");
                    var user = await context.Users.Find(x => x.email == model.email && x.status == "ACTIVE" && x.verified == true)
                        .Project<User>(projection).FirstOrDefaultAsync();

                    if (user != null)
                    {
                        if(BCrypt.Net.BCrypt.Verify(model.password, user.password))
                        {
                            var session = new PreSessionResponse(user.name, user.lastname, user.nick, user.birthday.ToShortDateString(),
                                                                 user.gender, user.photo, jwt.JwtBuilder(user));
                            response = Ok(new SessionResponse(session));
                        }
                        else
                        {
                            response = Ok(new BodyResponse(false, ConstantsResponse.bad_credentials));
                        }
                    }
                    else
                    {
                        response = Ok(new BodyResponse(false, ConstantsResponse.bad_credentials));
                    }
                }
            }
            catch
            {
                response = StatusCode(500, ConstantsResponse.ERROR_HTTP_500);
            }

            return response;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest model)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);
            var jwt = default(JWTService);

            try
            {
                if (!ModelState.IsValid)
                {
                    response = BadRequest(new ErrorResponse(ConstantsResponse.ERROR_HTTP_400, ModelState));
                }
                else
                {
                    context = new SocialNetworkDbContext();
                    jwt = new JWTService();

                    var exists = await context.Users.Find(x=>x.email == model.email).FirstOrDefaultAsync();
                    if(exists != null)
                    {
                        response = Ok(new BodyResponse(false, ConstantsResponse.email_exists));
                    }
                    else
                    {
                        User user = new User();
                        user.name = model.name;
                        user.lastname = model.lastname;
                        user.nick = Generators.getNickname(model.name, model.lastname);
                        user.gender = model.gender;
                        user.birthday = Convert.ToDateTime(model.birthday);
                        user.joindate = DateTime.Now;
                        user.email = model.email;
                        user.password = BCrypt.Net.BCrypt.HashPassword(model.password);
                        user.role = "USER";
                        user.status = "ACTIVE";

                        await context.Users.InsertOneAsync(user);

                        String tokenActivation = jwt.JwtActivate(user.id.ToString());
                        String linkActivation = $"{ActivationUrl}?activationCode={tokenActivation}";

                        //sendEmailAWS(user.name, user.email, linkActivation);
                        response = Ok(new BodyResponse(true, ConstantsResponse.register_success));
                    }
                }
            }
            catch
            {
                response = StatusCode(500, ConstantsResponse.ERROR_HTTP_500);
            }

            return response;
        }

        
        [HttpGet]
        [Route("activation")]
        public async Task<IActionResult> Activation(String activationCode)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                String id = getIdFromActivation(activationCode);

                if (!String.IsNullOrEmpty(id))
                {
                    var userUpdate = Builders<User>.Filter.Where(x=>x.id == id && x.status == "ACTIVE");
                    var fieldsUpdate = Builders<User>.Update
                        .Set(x => x.verified, true)
                        .Set(x => x.description, "There!");
                    var result = await context.Users.UpdateOneAsync(userUpdate, fieldsUpdate, new UpdateOptions { IsUpsert = true });

                    response = Ok(new BodyResponse(true, "Account activated"));
                }
                else
                {
                    response = Ok(new BodyResponse(false, ConstantsResponse.token_invalid));
                }
            }
            catch(MongoException e)
            {
                response = StatusCode(500, e.Message);
            }

            return response;
        }
    }
}