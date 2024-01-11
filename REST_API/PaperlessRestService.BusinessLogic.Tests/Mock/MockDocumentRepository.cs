using PaperlessRestService.BusinessLogic.Entities;
using PaperlessRestService.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Tests.Mock
{
    internal class MockDocumentRepository : IDocumentRepository
    {
        public bool DeleteDocument(int id)
        {
            return true;
        }


        public IEnumerable<Document> GetAllDocuments()
        {
            return statischeDaten;
        }

        public Document GetDocument(int id)
        {
            return statischeDaten.FirstOrDefault(x => x.Id == id);
        }

        public bool InsertDocument(Document document)
        {
            return true;
        }

        public bool UpdateDocument(Document document)
        {
            return true;
        }

        private static Document[] statischeDaten = new Document[]
        {
            new Document()
            {
                Id = 1,
                Title = "Testdokument 1",
                Content = "Dies ist ein Testdokument",
                Created = DateTime.Now,
                Created_Date = DateTime.Now,
                Modified = DateTime.Now,
                Added = DateTime.Now,
                Archive_Serial_Number = "123456789",
                Original_File_Name = "Testdokument 1",
                Archived_File_Name = "Testdokument 1",
                Storage_Path = 1,
                User_Can_Change = true,
                Data = Array.Empty<byte>(),
                CorrespondentId = 0,
                Correspondent = null,
                DocumentTypeId = 0,
                Document_Type = null,
                OwnerId = 0,
                Owner = null,
                TagsMapping = new List<DocumentTagMapping>()
                {
                    new DocumentTagMapping()
                    {
                        DocumentId = 1,
                        TagId = 1
                    },
                    new DocumentTagMapping()
                    {
                        DocumentId = 1,
                        TagId = 2
                    }
                },
                notes = Array.Empty<Notes>()
            }
        };
    }
}
