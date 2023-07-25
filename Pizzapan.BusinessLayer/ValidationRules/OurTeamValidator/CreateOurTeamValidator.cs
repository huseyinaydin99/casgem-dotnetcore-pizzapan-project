using FluentValidation;
using Pizzapan.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizzapan.BusinessLayer.ValidationRules.OurTeamValidator
{
    public class CreateOurTeamValidator:AbstractValidator<OurTeam>
    {
        public CreateOurTeamValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez");
            RuleFor(x=>x.Surname).NotEmpty().WithMessage("Soyisim alanı boş geçilemez");
            RuleFor(x=>x.Title).MinimumLength(3).WithMessage("Litfen en az 3 karakter veri girişi yapınız");
            RuleFor(x=>x.Title).MaximumLength(30).WithMessage("Litfen en fazla 30 karakter veri girişi yapınız");
           
        }

    }
}
