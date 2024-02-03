using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Complexion
{
    public interface IComplexionDto 
    {
        public int ComplexionId { get; set; }
        public string ComplexionName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}

