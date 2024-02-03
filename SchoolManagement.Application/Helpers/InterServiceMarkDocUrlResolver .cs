using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.InterServiceMark;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class InterServiceMarkDocUrlResolver : IValueResolver<InterServiceMark, InterServiceMarkDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public InterServiceMarkDocUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(InterServiceMark source, InterServiceMarkDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Doc))
            {

                return _config["ApiUrl"] + source.Doc;
            }

            return null;
        }
    }
}
