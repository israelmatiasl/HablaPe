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
        public async Task<IActionResult> GetAllPosts(int? page = 1)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var identity = getIdentity();
                
                List<String> following = new List<String>();
                following = await context.Follows.AsQueryable().Where(x => x.follower == identity.userId).Select(x => x.followed).ToListAsync();
                following.Add(identity.userId);

                
                await getPostsAsync(context, following, page.Value).ContinueWith((res) => {
                    if (res.IsCompletedSuccessfully)
                    {
                        response = Ok(res.Result);
                    }
                    else
                    {
                        response = Ok(new BodyResponse(false, ConstantsResponse.PostGetFailed));
                    }
                });
            }
            catch(Exception e)
            {
                response = StatusCode(500, e.Message);
            }

            return response;
        }


        [HttpGet]
        [Route("posts/{postId}")]
        public async Task<IActionResult> GetOnePost(String postId)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var post = await context.Posts.Find(x => x.id == postId).FirstOrDefaultAsync();
                if(post is null)
                {
                    response = Ok(new BodyResponse(false, ConstantsResponse.PostNotFound));
                }
                else
                {
                    await FillPosts(context, new List<Post> { post }).ContinueWith((res) =>
                    {
                        if (res.IsCompletedSuccessfully)
                        {
                            response = Ok(new PostResponse(res.Result[0]));
                        }
                        else
                        {
                            response = Ok(new BodyResponse(false, ConstantsResponse.PostGetFailed));
                        }
                    });
                }
            }
            catch(Exception e)
            {
                response = StatusCode(500, e.Message);
            }
            return response;
        }

        [HttpGet]
        [Route("users/{user}/posts")]
        public async Task<IActionResult> GetPostsByUser(String user, int? page = 1)
        {
            var response = default(IActionResult);
            var context = default(SocialNetworkDbContext);

            try
            {
                context = new SocialNetworkDbContext();
                var identity = getIdentity();
                string following = string.Empty;
                string userFound = await context.Users.AsQueryable().Where(x => x.nick == user).Select(x => x.id).FirstOrDefaultAsync();

                if (string.IsNullOrEmpty(userFound))
                {
                    response = Ok(new BodyResponse(false, ConstantsResponse.UserNotFound));
                }
                else
                {
                    if(userFound == identity.userId)
                        following = userFound;
                    else
                        following = await context.Follows.AsQueryable().Where(x => x.follower == identity.userId && x.followed == userFound).Select(x => x.followed).FirstOrDefaultAsync();
                    

                    if (string.IsNullOrEmpty(following))
                    {
                        response = Ok(new BodyResponse(false, ConstantsResponse.NotFollow));
                    }
                    else
                    {
                        await getPostsAsync(context, new List<string> { following }, page.Value).ContinueWith((res) => {
                            if (res.IsCompletedSuccessfully)
                            {
                                response = Ok(res.Result);
                            }
                            else
                            {
                                response = Ok(new BodyResponse(false, ConstantsResponse.PostGetFailed));
                            }
                        });
                    }
                }
            }
            catch (Exception e)
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

        Task<PostsResponse> getPostsAsync(SocialNetworkDbContext context, List<String> following, int currentPage)
        {
            return Task.Factory.StartNew(() => {
                var filterIn = Builders<Post>.Filter.In(x => x.user, following);
                PostsResponse res = new PostsResponse();

                var posts = context.Posts.Find(filterIn)
                    .Skip((currentPage - 1) * Constants.pageSizePosts)
                    .Limit(Constants.pageSizePosts)
                    .SortByDescending(x => x.createAt)
                    .ToListAsync().Result;
                var total = context.Posts.Find(filterIn).CountDocumentsAsync().Result;

                FillPosts(context, posts).ContinueWith(response => {
                    res.posts = response.Result;
                    res.pagination = new Pagination(CurrentUrlWithQuery, currentPage, Constants.pageSizePosts, total);
                }).Wait();
                return res;
            });
        }

        Task<List<PrePostResponse>> FillPosts(SocialNetworkDbContext context, List<Post> posts)
        {
            return Task.Factory.StartNew(() => {
                List<PrePostResponse> res = new List<PrePostResponse>();
                foreach (var post in posts)
                {
                    List<ImageResponse> imagesRes = new List<ImageResponse>();
                    var images = context.Images.Find(x => x.post == post.id).ToListAsync().Result;
                    foreach (var image in images)
                    {
                        imagesRes.Add(new ImageResponse(image.url));
                    }
                    var user = context.Users.AsQueryable().Where(x => x.id == post.user)
                        .Select(x => new UserResponse(x.id, x.name, x.lastname, x.photo, UserUrl))
                        .FirstOrDefaultAsync().Result;
                    res.Add(new PrePostResponse(user, post.id, post.textbody, imagesRes, post.createAt, post.updatedAt, PostUrl));
                }
                return res;
            });
        }
    }
}