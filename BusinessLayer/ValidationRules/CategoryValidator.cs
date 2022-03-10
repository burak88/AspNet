using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator:AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori açıklaması boş bırakılamaz");
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("En az 3 karakterli olmalıdır");
            RuleFor(x => x.CategoryName).MaximumLength(51).WithMessage("En fazla 50 karakter girilebilir");
        }
    }
}
