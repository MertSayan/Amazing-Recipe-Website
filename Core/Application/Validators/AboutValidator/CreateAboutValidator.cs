using Application.Features.Mediatr.Abouts.Commands;
using FluentValidation;

namespace Application.Validators.AboutValidator
{
    public class CreateAboutValidator:AbstractValidator<CreateAboutCommand>
    {
        public CreateAboutValidator()
        {
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)//başarısız olursa durur.
                .NotEmpty().WithMessage("Açıklama değeri boş bırakılamaz")
                .MinimumLength(50).WithMessage("Minimum 50 karakter girmelisiniz");
        }
    }
}
