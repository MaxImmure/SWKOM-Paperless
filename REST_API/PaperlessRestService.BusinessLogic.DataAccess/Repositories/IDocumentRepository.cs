﻿using PaperlessRestService.BusinessLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaperlessRestService.BusinessLogic.Repositories
{
    public interface IDocumentRepository
    {
        public Document GetDocument(int id);
        public IEnumerable<Document> GetAllDocuments();
        bool InsertDocument(Document document);
        bool UpdateDocument(Document document);
        bool DeleteDocument(int id);
    }
}
