using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Nationality
{
    public interface INationalityDto
    {

        public int NationalityId { get; set; }
        public string NationalityName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


    }
}
