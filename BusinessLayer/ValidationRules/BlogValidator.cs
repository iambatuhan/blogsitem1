using EntitiyLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
   public  class BlogValidator:AbstractValidator<Author>
    {
        public BlogValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Kullanıcı adı giriniz");
            RuleFor(x => x.AuthorAbout).NotEmpty().WithMessage("Boş geçilmez");
           
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Boş geçilmez");
 
            RuleFor(x => x.AuthorTitle).NotEmpty().WithMessage("Boş geçilmez");
         

            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre giriniz");
            

        }
    }
}
