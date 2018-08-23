using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Helpers.Validations
{
    public class StringRangeAttribute : ValidationAttribute
    {
        public string[] AllowableValues { get; set; }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (AllowableValues?.Contains(value?.ToString()) == true)
            {
                return ValidationResult.Success;
            }

            var msg = $"Please enter one of the allowed values: {string.Join(", ", (AllowableValues ?? new string[] { "No allowable values found" }))}.";
            return new ValidationResult(msg);
        }
    }
}
