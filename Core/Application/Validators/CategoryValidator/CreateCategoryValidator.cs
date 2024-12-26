using Application.Features.Mediatr.Categorys.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.CategoryValidator
{
    public class CreateCategoryValidator:AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Name değeri boş bırakılamaz")
                .MinimumLength(3).WithMessage("Name değeri minimum 3 harfli olmalıdır");
                
        }
    }
}
