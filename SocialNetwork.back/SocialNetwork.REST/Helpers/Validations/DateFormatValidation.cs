using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace SocialNetwork.Rest.Helpers.Validations
{
    public class DateFormatValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,ValidationContext validationContext)
        {
            DateTime date;
            var format = "dd/MM/yyyy";
            bool parsed = DateTime.TryParseExact((string)value, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
            if (!parsed) return new ValidationResult("Is a invalid date format.");
            return ValidationResult.Success;
        }
    }
}
