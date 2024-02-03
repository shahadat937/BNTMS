using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.FamilyNomination.converter;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.FamilyNomination
{ 
    public class FamilyNominationListDto
    {
        public int FamilyNominationId { get; set; }
        public int? TraineeId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? FundingDetailId { get; set; }
        public int? RelationTypeId { get; set; }
        public string? Remarks { get; set; }
        public bool? Status { get; set; }
        public bool IsActive { get; set; }
        public List<FamilyNominationListFormDto> traineeListForm { get; set; }

        //public int FamilyNominationId { get; set; }
        //public int? TraineeNominationId { get; set; }
        //public int? CourseDurationId { get; set; }
        //public int? TraineeId { get; set; }
        //public int? FamilyInfoId { get; set; }
        //public int? FundingDetailId { get; set; }
        //public int? RelationTypeId { get; set; }
        //public string? Remarks { get; set; }
        //public bool? Status { get; set; }
        //public int? MenuPosition { get; set; }
        //public bool IsActive { get; set; }
        //public List<FamilyNominationListFormDto> traineeListForm { get; set; }


    }
}
