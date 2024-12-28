using Application.Features.Mediatr.Recipes.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.RecipeValidator
{
    public class CreateRecipeValidator : AbstractValidator<CreateRecipeCommand>
    {
        public CreateRecipeValidator()
        {
            RuleFor(x => x.Title)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Başlık değeri boş bırakılamaz")
                .MinimumLength(5).WithMessage("Başlık değeri minimum 5 harfli olmalıdır")
                .MaximumLength(100).WithMessage("Başlık değeri 100 harfi aşmamalı");

            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Açıklama değeri boş bırakılamaz")
                .MinimumLength(50).WithMessage("Açıklama değeri minimum 50 harfli olmalıdır");


        }
    }
}
