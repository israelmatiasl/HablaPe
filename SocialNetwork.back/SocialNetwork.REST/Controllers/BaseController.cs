using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BL.BC.Services.Amazon;
using SocialNetwork.Rest.Models.Request;

namespace SocialNetwork.Rest.Controllers
{
    public class BaseController : Controller
    {
        protected string BaseUrl => $"{Request.Scheme}://{Request.Host}".ToLower();
        protected string CurrentUrl => $"{BaseUrl}{Request.Path}".ToLower();
        protected string ActivationUrl => $"{BaseUrl}/activation";
        protected string UserUrl => $"{BaseUrl}/profile";


        protected Identity getIdentity()
        {
            var identity = new Identity();

            try
            {
                var claims = User.Claims.ToList();
                identity.tokenId = claims.FirstOrDefault(x => x.Type == "jti").Value;
                identity.userId = claims.FirstOrDefault(x => x.Type == "userId").Value;
                identity.email = claims.FirstOrDefault(x => x.Type == "email_address").Value;
                identity.status = claims.FirstOrDefault(x => x.Type == "status").Value;
                //identity.role = claims.FirstOrDefault(x => x.Type == "role").Value;

                return identity;
            }
            catch
            {
                return null;
            }
        }

        protected String getIdFromActivation(String token)
        {
            try
            {
                String userId = null;
                var security = new JwtSecurityTokenHandler().ReadJwtToken(token);
                if (security != null)
                {
                    var claimbs = security.Claims.ToList();
                    String mode = claimbs.FirstOrDefault(x => x.Type == "mode").Value;
                    if (mode.Contains("act"))
                    {
                        userId = claimbs.FirstOrDefault(x => x.Type == "userId").Value;
                        DateTime dateValid = Convert.ToDateTime(claimbs.FirstOrDefault(x => x.Type == "creation").Value);
                    }
                }
                return userId;
            }
            catch
            {
                return null;
            }
        }


        protected void sendEmailAWS(String name, String receiverEmail, String linkActivation)
        {
            AmazonSES.sendEmail(name, receiverEmail, linkActivation);
        }
    }
}