using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator :AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.FirstName).NotNull();
            RuleFor(u => u.LastName).NotNull();
            RuleFor(u => u.Email).NotNull();
            RuleFor(u => u.Password).NotNull();
        }
    }
}
