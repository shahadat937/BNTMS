using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CodeValues
{
    public class SocialMediaDto : ISocialMediaDto 
    {


        public int SocialMediaId { get; set; }
        public int TraineeId { get; set; }
        public int SocialMediaTypeId { get; set; }
        public string? SocialMediaAccountName { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? SocialMediaTypeName { get; set; }
    }
}

