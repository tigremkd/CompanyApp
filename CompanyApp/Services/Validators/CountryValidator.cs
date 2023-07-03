using Domain.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class CountryValidator : AbstractValidator<CountryDto>
    {
        public CountryValidator()
        {
            RuleFor(a => a.CountryName)
               .NotEmpty()
               .WithMessage("{PropertyName} must not be empty")
               .MaximumLength(255)
               .WithMessage("{PropertyName} must not be longer than 255 characters");
        }
    }
}
