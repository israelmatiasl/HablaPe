using SocialNetwork.Rest.Helpers.Validations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Models.Request
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Name field is necessary.")]
        [MaxLength(30, ErrorMessage = "Name field must contain a maximum 30 characters.")]
        [MinLength(2, ErrorMessage = "Name field must contain at least 2 characters.")]
        public String name { get; set; }

        [Required(ErrorMessage = "Paternal surname field is necessary.")]
        [MaxLength(30, ErrorMessage = "Paternal surname field must contain a maximum 30 characters.")]
        [MinLength(2, ErrorMessage = "Paternal surname field must contain at least 2 characters.")]
        public String lastname { get; set; }

        [Required(ErrorMessage = "Gender field is necessary.")]
        [StringRange(AllowableValues = new[] { "Male", "Female", "Other" }, ErrorMessage = "Gender field is not a valid gender")]
        public String gender { get; set; }

        [Required(ErrorMessage = "Birthday field is necessary.")]
        public String birthday { get; set; }

        [Required(ErrorMessage = "Email field is necessary.")]
        [EmailAddress(ErrorMessage = "Email field is not a valid email")]
        public String email { get; set; }

        [Required(ErrorMessage = "Password field is necessary.")]
        [MinLength(8, ErrorMessage = "Password field must contain at least 8 characters.")]
        [MaxLength(50, ErrorMessage = "Password field must contain a maximum 50 characters.")]
        public String password { get; set; }
    }
}
