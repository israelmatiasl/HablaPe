using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Request
{
    public class PostRequest
    {
        public String textbody { get; set; }
        public IEnumerable<ImageRequest> images { get; set; }
        public DateTime createAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
