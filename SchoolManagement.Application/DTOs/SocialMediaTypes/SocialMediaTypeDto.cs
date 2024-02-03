using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMediaTypes
{
    public class SocialMediaTypeDto : ISocialMediaTypeDto
    {

        public int SocialMediaTypeId { get; set; }
        public string SocialMediaTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}

