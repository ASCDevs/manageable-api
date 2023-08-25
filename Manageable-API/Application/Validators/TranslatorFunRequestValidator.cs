using Domain.RequestsClass;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators
{
    public class TranslatorFunRequestValidator  : AbstractValidator<TranslatorFunRequest>
    {
        public TranslatorFunRequestValidator()
        {
            RuleFor(tf => tf.text)
                .NotEmpty().WithMessage("Texto não pode estar vazio")
                .MinimumLength(10).WithMessage("Texto mínimo deve ser de 10 caracteres.")
                .MaximumLength(100).WithMessage("Texto Máximo deve ser de 100 caracteres.");
        }
    }
}
