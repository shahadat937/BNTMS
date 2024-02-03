using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Gender
{
    public interface IGenderDto
    {

        public int GenderId { get; set; }
        public string GenderName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
