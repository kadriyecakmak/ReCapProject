using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator:AbstractValidator<Car>
    {
        public CarValidator()
        {//burası mesala bunun aşağısına delete ve update için olan kuralları bakşa bir method oluşturmadan yazabilirim dimi aşağı doğru 
            RuleFor(c => c.DailyPrice).NotEmpty();
            RuleFor(c=>c.CarName).MinimumLength(2);
            RuleFor(c => c.Description).MinimumLength(2);
            RuleFor(c => c.DailyPrice).GreaterThan(0);
            RuleFor(c => c.DailyPrice).GreaterThanOrEqualTo(300).When(p => p.CarId == 1);
            RuleFor(c => c.CarName).Must(StartWithK).WithMessage("Ürünler K harfi ile başlamalı çünkü benim başharfim :)");

        }

        private bool StartWithK(string arg)
        {
            return arg.StartsWith("K");
        }
    }
}
