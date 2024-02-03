using AutoMapper;
using SchoolManagement.Domain;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;

namespace SchoolManagement.Application.Helpers
{
    public class PhotoUrlResolver : IValueResolver<TraineeBioDataGeneralInfo, TraineeBioDataGeneralInfoDto, string>
    {
        //private readonly IConfiguration _config;
        //public PhotoUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public PhotoUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(TraineeBioDataGeneralInfo source, TraineeBioDataGeneralInfoDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.BnaPhotoUrl))
            {

                return _config["ApiUrl"] + source.BnaPhotoUrl;
            }

            return null;
        }
    }
}
