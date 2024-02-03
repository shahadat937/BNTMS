using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Weight
{
    public interface IWeightDto
    {
        public int WeightId { get; set; }
        public string WeightName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 