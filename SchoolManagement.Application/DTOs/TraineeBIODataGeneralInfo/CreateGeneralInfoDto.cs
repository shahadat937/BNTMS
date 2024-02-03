using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo
{
    public class CreateGeneralInfoDto 
    {
        public IFormFile file { get; set; }
        public CreateTraineeBioDataGeneralInfoDto TraineeBioDataGeneralInfoForm { get; set; }
    }
}
