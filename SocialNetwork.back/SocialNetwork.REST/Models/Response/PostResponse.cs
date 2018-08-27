using System;
using System.Collections.Generic;
using SocialNetwork.Rest.Helpers;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class PrePostResponse
    {
        public UserResponse user { get; set; }
        public String textbody { get; set; }
        public IEnumerable<ImageResponse> images { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public String url { get; set; }

        public PrePostResponse(UserResponse user, String id, String textbody, IEnumerable<ImageResponse> images, DateTime createdAt, DateTime updatedAt, String url)
        {
            this.user = user;
            this.textbody = textbody;
            this.images = images;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.url = $"{url}/{id}";
        }
    }

    public class PostResponse
    {
        public Boolean success { get; set; }
        public PrePostResponse post { get; set; }

        public PostResponse(PrePostResponse post)
        {
            this.success = true;
            this.post = post;
        }
    }

    public class PostsResponse
    {
        public Boolean success { get; set; }
        public List<PrePostResponse> posts { get; set; }
        public Pagination pagination { get; set; }

        public PostsResponse()
        {
            this.success = true;
        }

        public PostsResponse(List<PrePostResponse> posts, Pagination pagination)
        {
            this.success = true;
            this.posts = posts;
        }
    }
}
