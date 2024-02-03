using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Weight 
{
    public class CreateWeightDto : IWeightDto
    {
        public int WeightId { get; set; }
        public string WeightName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
