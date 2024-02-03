using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.RoutineSoftCopyUpload;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class RoutineSoftCopyUploadResolver : IValueResolver<RoutineSoftCopyUpload, RoutineSoftCopyUploadDto, string>
    {
        //private readonly IConfiguration _config;
        //public RoutineSoftCopyUploadResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public RoutineSoftCopyUploadResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(RoutineSoftCopyUpload source, RoutineSoftCopyUploadDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.DocumentLink))
            {

                return _config["ApiUrl"] + source.DocumentLink;
            }

            return null;
        }
    }
}
