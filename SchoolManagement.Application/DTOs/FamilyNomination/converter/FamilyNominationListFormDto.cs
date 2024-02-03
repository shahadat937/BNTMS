using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.FamilyNomination.converter
{ 
    public class FamilyNominationListFormDto
    {
        public int? CourseDurationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? RelationTypeId { get; set; }
        public int? FamilyInfoId { get; set; }
        public int? TraineeId { get; set; }
        public string? FullName { get; set; }
        public string? RelationType { get; set; }
        public bool? Status { get; set; }

        //public int? TraineeNominationId { get; set; }
        //public int? CourseDurationId { get; set; }
        //public int? TraineeId { get; set; }
        //public int? FamilyInfoId { get; set; }
        //public int? RelationTypeId { get; set; }
        //public bool? Status { get; set; }


    }
}
