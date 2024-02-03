using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ForeignCourseGOInfo;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class FileUploadUrlResolver : IValueResolver<ForeignCourseGOInfo, ForeignCourseGOInfoDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public FileUploadUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ForeignCourseGOInfo source, ForeignCourseGOInfoDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.FileUpload))
            {
                return _config["ApiUrl"]  + source.FileUpload;
            }

            return null;
        }
    }
}
