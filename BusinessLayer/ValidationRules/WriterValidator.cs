using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı boş bırakılamaz");
            RuleFor(x => x.WriterLastName).NotEmpty().WithMessage("Yazar soyadı  boş bırakılamaz");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Yazar mail boş bırakılamaz");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Yazar şifre boş bırakılamaz");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Yazar ünvan boş geçilemez");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Yazar hakkında boş bırakılamaz");
            
        }
    }
}
