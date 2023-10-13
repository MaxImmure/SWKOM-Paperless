using AutoMapper;
using PaperlessRestService.BusinessLogic.Entities;

namespace PaperlessRestService
{
    public class DTOMapperProfile : Profile
    {   
        public DTOMapperProfile()
        {
            CreateMap<Models.Correspondent, Correspondents>();
            CreateMap<Models.ApiCorrespondentsBody, Correspondents>();
            CreateMap<Models.Document, Document>();
            CreateMap<Models.DocumentType, DocumentType>();
        }
    }
}
