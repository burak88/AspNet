using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>       
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserMail).NotEmpty().WithMessage("Mail adresi boş bırakılamaz");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu boş bırakılamaz");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Ad kısmı boş bırakılamaz");
            RuleFor(x => x.Subject).MaximumLength(101).WithMessage("100 karakterden fazla karakter kullanmayınız ");
        }
    }
}
