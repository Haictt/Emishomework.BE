using DPHai.Fresher032023.EmisHomework.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DPHai.Fresher032023.EmisHomework.Common.Attributes
{


    /// <summary>
    /// Attribute required tự tạo
    /// </summary>
    public class CustomRequiredAttribute : ValidationAttribute
    {

        private readonly string DefaultErrorMessage = MISAResource.ValidateErrorMessage;

       

        public CustomRequiredAttribute()
        {
            
        }

        /// <summary>
        /// Ghi đè và trả về lỗi của mình
        /// </summary>
        /// <param name="value"></param>
        /// <param name="validationContext"></param>
        /// <returns></returns>
        /// <exception cref="ValidateException"></exception>
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                
                throw new ValidateException(MISAResource.ValidateErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}


