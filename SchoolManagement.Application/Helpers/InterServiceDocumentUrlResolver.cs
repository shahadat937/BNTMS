using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.Document;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class InterServiceDocumentUrlResolver : IValueResolver<Document, DocumentDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public InterServiceDocumentUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(Document source, DocumentDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.DocumentUpload))
            {
                return _config["ApiUrl"]  + source.DocumentUpload;
            }

            return null;
        }
    }
}
