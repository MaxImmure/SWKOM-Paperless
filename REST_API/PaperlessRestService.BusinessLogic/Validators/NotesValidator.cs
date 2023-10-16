﻿using FluentValidation;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Validators
{
    public class NotesValidator : AbstractValidator<Notes>
    {
        public NotesValidator()
        {
            RuleFor(n => n.Id).NotEmpty();
            RuleFor(n => n.Note).NotNull().NotEmpty();
            RuleFor(n => n.Created).NotEmpty();
            RuleFor(n => n.Document).NotEmpty();
            RuleFor(n => n.User).NotEmpty();
        }
    }
}
