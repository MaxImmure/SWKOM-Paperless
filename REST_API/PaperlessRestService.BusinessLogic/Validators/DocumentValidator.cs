using FluentValidation;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService.BusinessLogic.Validators
{
    public class DocumentValidator : AbstractValidator<Document>
    {
        public DocumentValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
            RuleFor(c => c.Correspondent).SetValidator(new CorrespondentsValidator());
            RuleFor(c => c.Document_Type).SetValidator(new DocumentTypeValidator());
            //RuleFor(c => c.Storage_Path).NotEmpty();
            RuleFor(c => c.Title).NotNull().NotEmpty();
            RuleFor(c => c.Content).NotNull().NotEmpty();
            RuleFor(c => c.Tags).NotEmpty();
            RuleFor(c => c.Created).NotEmpty();
            RuleFor(c => c.Created_Date).NotEmpty();
            //RuleFor(c => c.Modified).NotEmpty();
            //RuleFor(c => c.Added).NotEmpty();
            RuleFor(c => c.Archive_Serial_Number).NotEmpty();
            RuleFor(c => c.Original_File_Name).NotEmpty();
            RuleFor(c => c.Archived_File_Name).NotEmpty();

            RuleFor(c => c.User_Can_Change).NotEmpty();
            RuleFor(c => c.Owner).NotEmpty().SetValidator(new UserValidator());
            RuleFor(c => c.notes).NotEmpty().ForEach(n => n.SetValidator(new NotesValidator()));
        }
    }
}
