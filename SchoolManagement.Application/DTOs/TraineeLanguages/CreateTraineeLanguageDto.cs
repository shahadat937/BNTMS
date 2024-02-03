using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeLanguages 
{
    public class CreateTraineeLanguageDto : ITraineeLanguageDto
    {
        public int TraineeLanguageId { get; set; }
        public int TraineeId { get; set; }
        public int LanguageId { get; set; }

        public string? Speaking { get; set; }
        public string? Writing { get; set; }
        public string? Reading { get; set; }

        public string? AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
