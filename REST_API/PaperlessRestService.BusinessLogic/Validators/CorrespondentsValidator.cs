using FluentValidation;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Validators
{
    public class CorrespondentsValidator : AbstractValidator<Correspondents>
    {
        public CorrespondentsValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Slug).NotNull().NotEmpty();
            RuleFor(c => c.Name).NotNull().NotEmpty();
            RuleFor(c => c.Match).NotNull().NotEmpty();
            RuleFor(c => c.MatchingAlgorithm).NotEmpty();
            RuleFor(c => c.IsInsensitive).NotEmpty();
            RuleFor(c => c.Owner).NotEmpty();
        }
    }
}
