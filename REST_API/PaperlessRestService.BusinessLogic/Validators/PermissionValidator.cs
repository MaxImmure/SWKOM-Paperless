using FluentValidation;
using PaperlessRestService.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Validators
{
    public class PermissionValidator : AbstractValidator<Permission>
    {
        public PermissionValidator()
        {
            RuleFor(p => p.Users).ForEach(p => p.SetValidator(new UserValidator()));
            RuleFor(p => p.Groups).ForEach(p => p.SetValidator(new GroupValidator()));
        }
    }
}
