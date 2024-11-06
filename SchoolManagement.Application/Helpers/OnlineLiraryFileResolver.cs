using AutoMapper;
using Microsoft.Extensions.Configuration;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using SchoolManagement.Application.DTOs.ReadingMaterial;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Helpers
{
    public class OnlineLiraryFileResolver : IValueResolver<OnlineLibrary, OnlineLibraryDto, string>
    {
        private readonly IConfiguration _config;
        public OnlineLiraryFileResolver(IConfiguration config)
        {
            _config = config;
        }
        public string Resolve(OnlineLibrary source, OnlineLibraryDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.DocumentLink))
            {

                return _config["ApiUrl"] + source.DocumentLink;
            }

            return null;
        }
    }
}
