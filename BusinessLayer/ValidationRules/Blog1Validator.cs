using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class Blog1Validator : AbstractValidator<Blog>
    {
        public Blog1Validator()
        {
            
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Boş geçilmez");
            RuleFor(x => x.BlogDate).NotEmpty().WithMessage("Boş geçilmez");
  
       
         
         



        }
    }
}