using EntityLayer.Concrate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurName).NotEmpty().WithMessage("Açıklamayı  boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Açıklamayı  boş geçemezsiniz.");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Maili  boş geçemezsiniz.");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifreyi  boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar Ünvanı  boş geçemezsiniz.");
            RuleFor(x => x.WriterSurName).MaximumLength(100).WithMessage("Lütfen 100 karakterden fazla giriş yapmayınız.");

            RuleFor(x => x.WriterSurName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(x => x.WriterSurName).MaximumLength(25).WithMessage("Lütfen 25 karakterden fazla giriş yapmayınız.");
        }
    }
}
