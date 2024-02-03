using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Electeds 
{
    public class CreateElectedDto : IElectedDto
    {
        public int ElectedId { get; set; }
        public string ElectedType { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
