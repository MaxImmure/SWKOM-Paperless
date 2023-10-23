using FluentValidation;
using PaperlessRestService.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            // no rules yet
        }
    }
}
