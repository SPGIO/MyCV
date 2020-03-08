using MyCV.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCV.Attributes
{
    public class ImageAttribute : ValidationAttribute
    {
        public ImageAttribute()
        {

        }

        public string GetErrorMessage() => "Image can't be null";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var image = (ImageFile) validationContext.ObjectInstance;
            if(image == null)
            {
                return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }
    }
}
