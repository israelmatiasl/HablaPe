using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using SocialNetwork.DL.DM;
using SocialNetwork.Rest.Helpers;
using SocialNetwork.Rest.Models.Request;
using SocialNetwork.Rest.Models.Response;

namespace SocialNetwork.Rest.Controllers
{
    public class PostsController : BaseController
    {
        [HttpGet]
        [Route("posts")]
        public async Task<IActionResult> GetPosts()
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var identity = getIdentity();

                List<PostResponse> posts = new List<PostResponse>();
                await context.Follows.Find(x => x.follower == identity.userId).ForEachAsync(following => {
                    context.Posts.Find(x => x.user == following.followed).ForEachAsync(post =>
                    {
                        List<ImagesResponse> images = new List<ImagesResponse>();
                        context.Images.Find(x =>x.post == post.id).ForEachAsync(image =>
                        {
                            images.Add(new ImagesResponse(image.url, image.createdAt));
                        });
                        var user = context.Users.Find(x => x.id == post.user && x.status == "ACTIVE").FirstOrDefaultAsync().Result;
                        UserResponse userResponse = new UserResponse(user.name, user.lastname, user.photo, $"{UserUrl}/{user.id}");

                        posts.Add(new PostResponse(userResponse, post.textbody, images, post.createAt, post.updatedAt, ""));
                    });
                });
                //await context.Follows.Find(x => x.follower == identity.userId).ForEachAsync(following => {
                //    context.Posts.Find(x => x.user == following.followed).SortBy(x=>x.createAt).ForEachAsync(post =>
                //    {
                //        List<ImagesResponse> images = new List<ImagesResponse>();
                //        context.Images.Find(x => x.post == post.id).ForEachAsync(image =>
                //        {
                //            images.Add(new ImagesResponse(image.url, image.createdAt));
                //        });

                //        var user = context.Users.AsQueryable().Where(x=>x.id == post.user).Select(x => 
                //            new UserResponse(x.name, x.lastname, x.photo, ""))
                //            .FirstOrDefaultAsync().Result;

                //        posts.Add(new PostResponse(user, post.textbody, images, post.createAt, post.updatedAt, ""));
                //    });
                //});

                //await context.Posts.Find(new BsonDocument()).ForEachAsync(post =>
                //{
                //    List<ImagesResponse> images = new List<ImagesResponse>();
                //    context.Images.Find(x =>x.post == post.id).ForEachAsync(image =>
                //    {
                //        images.Add(new ImagesResponse { id = image.id, url = image.url, createdAt = image.createdAt });
                //    });
                    
                //    var user = context.Users.Find(x => x.id == post.user && x.status == "ACTIVE").FirstOrDefaultAsync().Result;
                //    UserResponse userResponse = new UserResponse(user.name, user.lastname, user.photo, $"{UserUrl}/{user.id}");

                //    posts.Add(new PostResponse() { id = post.id, user = userResponse, textbody = post.textbody, images = images, createdAt = post.createAt, updatedAt = post.updatedAt });

                //});
                
                
                response = Ok(posts);
            }
            catch(Exception e)
            {
                response = StatusCode(500, e.Message);
            }

            return response;
        }



        
        [HttpPost]
        [Route("posts")]
        public async Task<IActionResult> CreatePost([FromBody] PostRequest model)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                if (!ModelState.IsValid)
                {
                    response = BadRequest(new ErrorResponse(ConstantsResponse.ERROR_HTTP_400, ModelState));
                }
                else
                {
                    context = new SocialNetworkDbContext();
                    var identity = getIdentity();

                    var post = new Post();
                    post.user = identity.userId;
                    post.textbody = model.textbody;
                    post.createAt = DateTime.Now;

                    await context.Posts.InsertOneAsync(post);

                    if(model.images != null && model.images.Count() > 0)
                    {
                        foreach (var item in model.images)
                        {
                            var image = new Image();
                            image.post = post.id;
                            image.url = item.url;
                            image.createdAt = DateTime.Now;

                            await context.Images.InsertOneAsync(image);
                        }
                    }

                    response = Ok(new BodyResponse(true, ConstantsResponse.PostSuccess));
                }
            }
            catch(Exception e)
            {
                response = StatusCode(500, e.Message);
            }

            return response;
        }
    }
}