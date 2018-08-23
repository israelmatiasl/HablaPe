using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class PostResponse
    {
        public UserResponse user { get; set; }
        public String textbody { get; set; }
        public IEnumerable<ImagesResponse> images { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public String url { get; set; }

        public PostResponse(UserResponse user, String textbody, IEnumerable<ImagesResponse> images, DateTime createdAt, DateTime updatedAt, String url)
        {
            this.user = user;
            this.textbody = textbody;
            this.images = images;
            this.createdAt = createdAt;
            this.updatedAt = updatedAt;
            this.url = url;
        }
    }

    public class ListPostsResponse
    {
        public Boolean success { get; set; }
        public List<PostResponse> posts { get; set; }

        public ListPostsResponse(List<PostResponse> posts)
        {
            this.success = true;
            this.posts = posts;
        }
    }
}
