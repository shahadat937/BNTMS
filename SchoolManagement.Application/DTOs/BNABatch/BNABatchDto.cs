using System;

namespace SchoolManagement.Application.DTOs.BnaBatch
{
    public class BnaBatchDto : IBnaBatchDto 
    {
        public int BnaBatchId { get; set; }
        public string BatchName { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public int CompleteStatus { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
