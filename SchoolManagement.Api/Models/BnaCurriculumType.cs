using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaCurriculumType
    {
        public BnaCurriculumType()
        {
            BnaCurriculumUpdates = new HashSet<BnaCurriculumUpdate>();
            BnaExamMarks = new HashSet<BnaExamMark>();
            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();

            CourseSections = new HashSet<CourseSection>();
        }

        public int BnaCurriculumTypeId { get; set; }
        public string CurriculumType { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaCurriculumUpdate> BnaCurriculumUpdates { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }
        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }

        public virtual ICollection<CourseSection> CourseSections { get; set; }
    }
}
