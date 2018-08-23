using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class ImagesResponse
    {
        public String id { get; set; }
        public String url { get; set; }
        public DateTime createdAt { get; set; }

        public ImagesResponse(String url, DateTime createdAt)
        {
            this.url = url;
            this.createdAt = createdAt;
        }
    }
}
