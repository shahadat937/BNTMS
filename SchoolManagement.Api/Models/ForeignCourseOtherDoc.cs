using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ForeignCourseOtherDoc
    {
        public int ForeignCourseOtherDocId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public bool? Ticket { get; set; }
        public bool? Visa { get; set; }
        public bool? Passport { get; set; }
        public bool? CovidTest { get; set; }
        public bool? MedicalTest { get; set; }
        public bool? DgfiBreafing { get; set; }
        public bool? DniBreafing { get; set; }
        public bool? EmbassiBreafing { get; set; }
        public bool? FinancialSanction { get; set; }
        public bool? ExBdLeave { get; set; }
        public string FamilyGo { get; set; }
        public bool? MedicalDocument { get; set; }
        public string Remark { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
        public virtual TraineeNomination TraineeNomination { get; set; }
    }
}
