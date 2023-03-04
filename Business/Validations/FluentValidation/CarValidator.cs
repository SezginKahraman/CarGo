using Business.Constants;
using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Validations.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(x => x.Name).MinimumLength(2).WithMessage(Messages.CarMinNameLengthError);
            RuleFor(x => x.DailyPrice).GreaterThan(0).WithMessage(Messages.CarDailyPriceError);
        }
    }
}
