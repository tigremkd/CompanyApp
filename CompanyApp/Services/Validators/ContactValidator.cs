using Domain.DTOS;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Validators
{
    public class ContactValidator : AbstractValidator<ContactDto>
    {
        public ContactValidator()
        {
            RuleFor(a => a.ContactName)
               .NotEmpty()
               .WithMessage("{PropertyName} must not be empty")
               .MaximumLength(255)
               .WithMessage("{PropertyName} must not be longer than 255 characters");

            RuleFor(c => c.Company)
                .NotNull()
                .WithMessage("{PropertyName} must not be emtpy")
                ;

            RuleFor(c => c.Country)
                .NotNull()
                .WithMessage("{PropertyName} must not be emtpy"); ;
        }
    }
}
