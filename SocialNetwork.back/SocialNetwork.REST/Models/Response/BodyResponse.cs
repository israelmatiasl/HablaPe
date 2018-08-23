using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Response
{
    public class BodyResponse
    {
        public Boolean success { get; set; }
        public String message { get; set; }

        public BodyResponse(Boolean success, String message)
        {
            this.success = success;
            this.message = message;
        }
    }
}
