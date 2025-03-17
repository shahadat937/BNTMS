using AutoMapper;
using SchoolManagement.Domain;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.DTOs.BaseSchoolNames;
using SchoolManagement.Application.DTOs.ErrorLog;

namespace SchoolManagement.Application.Helpers
{
    public class ErrorLogUrlResolver : IValueResolver<ErrorLog, ErrorLogDto, string>
    {
        private readonly IConfiguration _config;
        public ErrorLogUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ErrorLog source, ErrorLogDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.FileUpload))
            {

                return _config["ApiUrl"] + source.FileUpload;
            }

            return null;
        }
    }
}
