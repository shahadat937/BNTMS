using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.StepRelation
{
    public interface IStepRelationDto
    {

        public int StepRelationId { get; set; }
        public string? StepRelationType { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
