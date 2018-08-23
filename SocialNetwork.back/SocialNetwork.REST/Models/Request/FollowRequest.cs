using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Request
{
    public class FollowRequest
    {
        [Required]
        public String followed { get; set; }
    }
}
