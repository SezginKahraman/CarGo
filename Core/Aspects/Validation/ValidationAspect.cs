using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _typeof;
        public ValidationAspect(Type validator)
        {
            //Aspects takes the Type class as the ctor method.

            //Check if the Type matches with validator class.

            if (!typeof(IValidator).IsAssignableFrom(validator))
            {
                throw new System.Exception("Bu bir validator type değil !");

            }
            _typeof = validator;
        }
        //The Intercept method in the MethodInterception base will always be running.
        //So we can overload it's onbefore Method to see if the proceeding will be running or not.
        public override void OnBefore(IInvocation invocation)
        {
            //This part makes the equiliviant of the belof code in th running time with the reflection.
            //ProductValidator productValidator = new ProductValidator();
            var validator = (IValidator)Activator.CreateInstance(_typeof);

            //The BaseType of the validator is like AbstractValidator<Car>. Get the GenericArgument list, get the type of the first element.
            var entityType = _typeof.BaseType.GetGenericArguments()[0];
            //entityType is like => Car 

            //Lets find the elements which are going to be validated in the arguments of the method.
            var validatedElement = invocation.Arguments.First(x=>x.GetType() == _typeof);

            ValidationTool.Validate(validator, validatedElement);

        }

    }
}
