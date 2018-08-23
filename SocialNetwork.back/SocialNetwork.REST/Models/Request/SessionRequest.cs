using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Request
{
    public class SessionRequest
    {
        [Required(ErrorMessage = "Email is required")]
        [MinLength(5, ErrorMessage = "Please enter a email address with more than 5 characters")]
        [MaxLength(30, ErrorMessage = "Plase enter a email address with less than 30 characters")]
        [EmailAddress(ErrorMessage = "Plase enter a valid email address")]
        public String email { get; set; }


        [Required(ErrorMessage = "Password is required")]
        [MinLength(1, ErrorMessage = "Please enter a password with more than 8 characters")]
        [MaxLength(30, ErrorMessage = "Plase enter a password with less than 30 characters")]
        public String password { get; set; }
    }
}
