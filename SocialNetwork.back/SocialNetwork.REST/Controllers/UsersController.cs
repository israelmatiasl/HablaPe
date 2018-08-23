using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Driver;
using SocialNetwork.DL.DM;

namespace SocialNetwork.Rest.Controllers
{
    public class UsersController : BaseController
    {
        [HttpGet]
        [Route("users")]
        public async Task<IActionResult> Get()
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var users = await context.Users.Find(new BsonDocument()).ToListAsync();
                response = Ok(users);
            }
            catch
            {
                response = StatusCode(500);
            }

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
        
    }
}