using FluentValidation;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Validators
{
    public class DocumentTypeValidator : AbstractValidator<DocumentType>
    {
        public DocumentTypeValidator()
        {
            RuleFor(dt => dt.Id).NotEmpty();
            RuleFor(dt => dt.Slug).NotNull().NotEmpty();
            RuleFor(dt => dt.Name).NotNull().NotEmpty();
            // no rule for match
            // no rule for match algorithm
            RuleFor(dt => dt.IsInsensitive).NotNull();
            RuleFor(dt => dt.Document_Count).NotEmpty();
            // no rule for owner

            // Todo IPermissions validator for view and change
        }
    }
}
