using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.ForeignCourseOtherDoc.converter
{ 
    public class TraineeListForeignFormDto
    {
        public int? CourseNameId { get; set; }
        public int? FinancialSanctionId { get; set; }
        public int? CourseDurationId { get; set; }
        public bool? Visa { get; set; }
        public string? TraineePNo { get; set; }
        public int? TraineeId { get; set; }
        public int? TraineeNominationId { get; set; }
        public string? TraineeName { get; set; }
        public string? RankPosition { get; set; }
        public bool? Ticket { get; set; }
        public bool? Passport { get; set; }
        public bool? CovidTest { get; set; }
        public bool? DgfiBreafing { get; set; }
        public bool? DniBreafing { get; set; }
        public bool? EmbassiBreafing { get; set; }
        public bool? FinancialSanction { get; set; }
        public bool? ExBdLeave { get; set; }
        public string? FamilyGo { get; set; }
        public bool? MedicalDocument { get; set; }
        public int? ForeignCourseOtherDocId { get; set; }
        public string? CreatedBy { get; set; } = null!;
        public DateTime? DateCreated { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? Remark { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        //public int? CourseDurationId { get; set; }
        //public int? CourseNameId { get; set; }
        //public int? TraineeNominationId { get; set; }
        //public int? TraineeId { get; set; }
        //public bool? Ticket { get; set; }
        //public bool? Visa { get; set; }
        //public bool? Passport { get; set; }
        //public bool? CovidTest { get; set; }
        //public bool? MedicalTest { get; set; }
    }
}
