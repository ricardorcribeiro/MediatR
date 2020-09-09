using FluentValidation;
using Shopping.Domain.Commands.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shopping.Domain.Validation
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerRequest>
    {
        public CreateCustomerValidator()
        {
            RuleFor(a => a.Nome)
    .NotEmpty()
    .WithMessage("O Nome é obrigatório");
        }
    }
}
