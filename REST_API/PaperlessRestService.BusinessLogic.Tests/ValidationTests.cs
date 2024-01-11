using FluentValidation;
using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.Validators;

namespace PaperlessRestService.BusinessLogic.Tests
{
    public class ValidationTests
    {
        public ValidationTests()
        {
            correspondentsValidator = new CorrespondentsValidator();
            documentTypeValidator = new DocumentTypeValidator();
            groupValidator = new GroupValidator();
            notesValidator = new NotesValidator();
            userValidator = new UserValidator();
        }

        [Fact]
        public void CorrespondentsValidator_Ok()
        {
            Correspondents correspondentsOK = new Correspondents()
            {
                Id = 1,
                IsInsensitive = true,
                Match = "match",
                MatchingAlgorithm = 1,
                Name = "name",
                Owner = 1,
                Slug = "slug",
                LastCorrespondents = null,
                LastCorrespondentsId = 0
            };

            var result = correspondentsValidator.Validate(correspondentsOK);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void CorrespondentsValidator_Fail()
        {
            Correspondents correspondentsOK = new Correspondents()
            {
                Id = 0,
                IsInsensitive = true,
                Match = null,
                MatchingAlgorithm = 1,
                Name = "name",
                Owner = 0,
                Slug = "slug",
                LastCorrespondents = null,
                LastCorrespondentsId = 0
            };

            var result = correspondentsValidator.Validate(correspondentsOK);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void DocumentTypeValidator_Ok()
        {
            DocumentType typeOk = new DocumentType()
            {
                Id = 1,
                Name = "name",
                Slug = "slug",
                Match = "match",
                MatchingAlgorithm = 1,
                IsInsensitive = true,
                Document_Count = 10,
                Owner = null
            };

            var result = documentTypeValidator.Validate(typeOk);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void DocumentTypeValidator_Fail()
        {
            DocumentType typeOk = new DocumentType()
            {
                Id = -1,
                Name = "name",
                Slug = "slug",
                Match = "match",
                MatchingAlgorithm = 1,
                IsInsensitive = true,
                Document_Count = 0,
                Owner = null
            };

            var result = documentTypeValidator.Validate(typeOk);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void GroupValidator_Ok()
        {
            Group group = new Group()
            {
                Id = 1,
                Name = "name",
                Permissions = new List<PermissionGroupMapping>()
                {
                    new PermissionGroupMapping()
                    {
                        GroupId = 1,
                        PermissionName = "write"
                    }
                },
            };

            var result = groupValidator.Validate(group);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void GroupValidator_Fail()
        {
            Group group = new Group()
            {
                Id = 0,
                Name = null,
                Permissions = new List<PermissionGroupMapping>()
                {
                    new PermissionGroupMapping()
                    {
                        GroupId = 1,
                        PermissionName = "write"
                    }
                },
            };

            var result = groupValidator.Validate(group);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void NotesValidator_Ok()
        {
            Notes note = new Notes()
            {
                Id = 1,
                DocumentId = 1,
                UserId = 1,
                Note = "note",
                Created = DateTime.Now,
            };

            var result = notesValidator.Validate(note);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void NotesValidator_Fail()
        {
            Notes note = new Notes()
            {
                Id = -1,
                DocumentId = 0,
                UserId = 0,
                Note = "",
                Created = DateTime.Now,
            };

            var result = notesValidator.Validate(note);

            Assert.False(result.IsValid);
        }

        [Fact]
        public void UserValidator_Ok()
        {
            User user = new User()
            {
                Id = 1,
                Username = "username",
                Email = "email",
                FirstName = "firstname",
                LastName = "lastname",
                DateJoined = DateTime.Now,
                IsStaff = false,
                IsActive = true,
                IsSuperuser = false,
                Groups = new int[] { 1 },
                UserPermissions = new string[] { "write" },
                InheritedPermissions = Array.Empty<string>()
            };

            var result = userValidator.Validate(user);

            Assert.True(result.IsValid);
        }

        [Fact]
        public void UserValidator_Fail()
        {
            User user = new User()
            {
                Id = 0,
                Username = "username",
                Email = null,
                FirstName = "firstname",
                LastName = "lastname",
                DateJoined = DateTime.Now,
                IsStaff = false,
                IsActive = true,
                IsSuperuser = false,
                Groups = new int[] { 1 },
                UserPermissions = new string[] { "write" },
                InheritedPermissions = Array.Empty<string>()
            };

            var result = userValidator.Validate(user);

            Assert.False(result.IsValid);
        }

        IValidator<Correspondents> correspondentsValidator;
        IValidator<DocumentType> documentTypeValidator;
        IValidator<Group> groupValidator;
        IValidator<Notes> notesValidator;
        IValidator<User> userValidator;
    }
}
