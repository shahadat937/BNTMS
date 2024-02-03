using AutoMapper;
using SchoolManagement.Domain;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.DTOs.ForeignCourseOthersDocument;

namespace SchoolManagement.Application.Helpers 
{
    public class OtherDocumentUploadUrlResolver : IValueResolver<ForeignCourseOthersDocument, ForeignCourseOthersDocumentDto, string>
    {
       

        private readonly IConfiguration _config;
        public OtherDocumentUploadUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ForeignCourseOthersDocument source, ForeignCourseOthersDocumentDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.FileUpload))
            {

                return _config["ApiUrl"] + source.FileUpload;
            }

            return null;
        }
    }
}
