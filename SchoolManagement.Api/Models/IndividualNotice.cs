using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class IndividualNotice
    {
        public int IndividualNoticeId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? CourseInstructorId { get; set; }
        public int? TraineeId { get; set; }
        public int? Status { get; set; }
        public string NoticeHeading { get; set; }
        public string NoticeDetails { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual BaseSchoolName BaseSchoolName { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseInstructor CourseInstructor { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
        public virtual TraineeNomination TraineeNomination { get; set; }
    }
}
