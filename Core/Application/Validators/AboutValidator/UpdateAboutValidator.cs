using Application.Features.Mediatr.Abouts.Commands;
using FluentValidation;

namespace Application.Validators.AboutValidator
{
    public class UpdateAboutValidator:AbstractValidator<UpdateAboutCommand>
    {
        public UpdateAboutValidator()
        {
            RuleFor(x => x.Description)
                .Cascade(CascadeMode.Stop)//başarısız olursa durur.
                .NotEmpty().WithMessage("Açıklama değeri boş bırakılamaz")
                .MinimumLength(50).WithMessage("Minimum 50 karakter girmelisiniz");
        }
    }
}
