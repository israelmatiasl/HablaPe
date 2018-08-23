using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SocialNetwork.DL.DM;
using SocialNetwork.Rest.Helpers;
using SocialNetwork.Rest.Models.Request;
using SocialNetwork.Rest.Models.Response;

namespace SocialNetwork.Rest.Controllers
{
    public class FollowsController : BaseController
    {
        [HttpGet]
        [Route("following")]
        public async Task<IActionResult> GetFollowed()
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var identity = getIdentity();

                List<UserResponse> usersFollowing = new List<UserResponse>();
                await context.Follows.Find(x => x.follower == identity.userId).ForEachAsync(following => {
                    var user = context.Users.Find(x => x.id == following.followed).FirstOrDefaultAsync().Result;
                    usersFollowing.Add(new UserResponse(user.id, user.name, user.lastname, user.email));
                });

                response = Ok(new ListUserResponse(usersFollowing));
            }
            catch (Exception ex)
            {
                response = StatusCode(500, ex.Message);
            }
            return response;
        }


        [HttpGet]
        [Route("follows/followme")]
        public async Task<IActionResult> GetFollowMe()
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var identity = getIdentity();
                List<UserResponse> usersFollowing = new List<UserResponse>();
                await context.Follows.Find(x => x.followed == identity.userId).ForEachAsync(following => {
                    var user = context.Users.Find(x => x.id == following.follower).FirstOrDefaultAsync().Result;
                    usersFollowing.Add(new UserResponse(user.id, user.name, user.lastname, user.email));
                });

                response = Ok(new ListUserResponse(usersFollowing));
            }
            catch (Exception ex)
            {
                response = StatusCode(500, ex.Message);
            }
            return response;
        }


        [HttpPost]
        [Route("follows/{followed}")]
        public async Task<IActionResult> Follow(String followed)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var identity = getIdentity();

                var followExists = await context.Follows.Find(x => x.follower == identity.userId && x.followed == followed).FirstOrDefaultAsync();
                if (followExists != null)
                {
                    response = Ok(new BodyResponse(false, ConstantsResponse.FollowFailed));
                }
                else
                {
                    var follow = new Follow();
                    follow.follower = identity.userId;
                    follow.followed = followed;
                    follow.createdAt = DateTime.Now;

                    await context.Follows.InsertOneAsync(follow);
                    response = Ok(new BodyResponse(true, ConstantsResponse.FollowSuccess));
                }
            }
            catch (Exception ex)
            {
                response = StatusCode(500, ex.Message);
            }
            return response;
        }


        [HttpDelete]
        [Route("follows/{followed}")]
        public async Task<IActionResult> UnFollow(String followed)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var identity = getIdentity();

                var followExists = await context.Follows.Find(x => x.follower == identity.userId && x.followed == followed).FirstOrDefaultAsync();
                if (followExists is null)
                {
                    response = Ok(new BodyResponse(false, ConstantsResponse.UnFollowFailed));
                }
                else
                {
                    await context.Follows.DeleteOneAsync(x => x.id == followExists.id);
                    response = Ok(new BodyResponse(true, ConstantsResponse.UnFollowSuccess));
                }
            }
            catch (Exception ex)
            {
                response = StatusCode(500, ex.Message);
            }
            return response;
        }
    }
}