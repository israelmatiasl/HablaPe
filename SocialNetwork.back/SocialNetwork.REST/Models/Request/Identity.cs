using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Request
{
    public class Identity
    {
        public String tokenId { get; set; }
        public String userId { get; set; }
        public String email { get; set; }
        public String status { get; set; }
        public String role { get; set; }
    }
}
