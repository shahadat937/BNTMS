﻿using SchoolManagement.Application.DTOs.CodeValues;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.SocialMedias 
{
    public class CreateSocialMediaDto : ISocialMediaDto
    {
        public int SocialMediaId { get; set; }
        public int TraineeId { get; set; }
        public int SocialMediaTypeId { get; set; }
        public string? SocialMediaAccountName { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 