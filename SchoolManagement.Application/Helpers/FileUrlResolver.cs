using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using Microsoft.Extensions.Configuration;

namespace SchoolManagement.Application.Helpers
{
    public class FileUrlResolver : IValueResolver<ReadingMaterial, ReadingMaterialDto, string>
    {
        //private readonly IConfiguration _config;
        //public FileUrlResolver(IConfiguration config)
        //{
        //    _config = config;
        //}

        private readonly IConfiguration _config;
        public FileUrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(ReadingMaterial source, ReadingMaterialDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.DocumentLink))
            {

                return _config["ApiUrl"] + source.DocumentLink;
            }

            return null;
        }
    }
}
