using Application.Features.Mediatr.Users.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Validators.UserValidator
{
    public class CreateUserValidator:AbstractValidator<CreateUserCommand>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("İsim değeri boş bırakılamaz")
                .MinimumLength(3).WithMessage("İsim değeri minimum 3 harfli olmalıdır")
                .MaximumLength(20).WithMessage("İsim değeri 20 harfi aşmamalı");

            RuleFor(x => x.Surname)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Soyad değeri boş bırakılamaz")
                .MinimumLength(2).WithMessage("Soyad değeri minimum 3 harfli olmalıdır")
                .MaximumLength(20).WithMessage("Soyad değeri 20 harfi aşmamalı");

            RuleFor(x => x.Email)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Mail değeri boş bırakılamaz")
                .EmailAddress().WithMessage("Girilen değer mail formatında olmalıdır")
                .MinimumLength(5).WithMessage("Mail, minimum 5 haneli olmalıdır")
                .MaximumLength(50).WithMessage("Mail, maksimum 50 haneli olmalıdır");

            RuleFor(x => x.Password)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Şifre Değeri boş bırakılamaz")
                .MinimumLength(3).WithMessage("Şifre en az 6 haneli olmalıdır");

            RuleFor(x => x.Phone)
                 .Cascade(CascadeMode.Stop)
                 .NotEmpty().WithMessage("Telefon numarası boş bırakılamaz.")
                 .Matches(@"^\d{11}$").WithMessage("Telefon numarası 11 haneli olmalı ve sadece rakamlardan oluşmalıdır.");

            RuleFor(x => x.BirthDate)
               .Cascade(CascadeMode.Stop)
               .NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz.")
               .LessThan(DateTime.Now).WithMessage("Doğum tarihi bugünden daha ileri bir tarih olamaz.")
               .Must(BeAtLeast18YearsOld).WithMessage("Kullanıcının en az 18 yaşında olması gerekiyor.");
        }

        private bool BeAtLeast18YearsOld(DateTime birthdate)
        {
            return birthdate <= DateTime.Now.AddYears(-18);
        }
    }
}
