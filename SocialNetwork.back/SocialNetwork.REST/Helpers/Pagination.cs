using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Helpers
{
    public class Pagination
    {
        public string self { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string prev { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string next { get; set; }

        public Pagination(string url, int page, int items, float total)
        {
            this.self = url;
            double pages = Math.Ceiling(total / items);

            if (!self.Contains($"?page={page}"))
            {
                self += $"?page={page}";
            }
            if (page > 1)
            {
                prev = self.Replace($"page={page}", $"page={Convert.ToInt32(page-1)}");
            }
            if(page < pages)
            {
                next = self.Replace($"page={page}", $"page={Convert.ToInt32(page+1)}");
            }
        }
    }
}
