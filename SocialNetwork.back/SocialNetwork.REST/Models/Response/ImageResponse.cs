using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class ImageResponse
    {
        public String url { get; set; }
        
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public DateTime createdAt { get; set; }

        public ImageResponse(String url)
        {
            this.url = url;
        }

        public ImageResponse(String url, DateTime createdAt)
        {
            this.url = url;
            this.createdAt = createdAt;
        }
    }
}
