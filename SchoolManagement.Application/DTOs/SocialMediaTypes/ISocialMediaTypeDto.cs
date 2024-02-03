using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMediaTypes
{
    public interface ISocialMediaTypeDto
    {
        public int SocialMediaTypeId { get; set; }
        public string SocialMediaTypeName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 