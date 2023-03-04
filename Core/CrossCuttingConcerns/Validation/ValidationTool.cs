using Core.Entity;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            //Create the instance of validationContext
            var context = new ValidationContext<object>(entity);

            //Make the validation
            var result = validator.Validate(context);

            //check if isvalid
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        } 

    }
}
