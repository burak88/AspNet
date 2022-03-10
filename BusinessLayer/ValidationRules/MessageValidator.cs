using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator:AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.Reciever).NotEmpty().WithMessage("Alıcı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj alanı boş geçilemez");
            RuleFor(x => x.Subject).MaximumLength(80).WithMessage("Konu 80 karekteri geçemez");
            RuleFor(x => x.Reciever).EmailAddress().WithMessage("mail adresini doğru şekilde giriniz");

        }
    }
}
