using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class BnaCurriculumType : BaseDomainEntity
    {
        public BnaCurriculumType()
        {
            BnaCurriculumUpdates = new HashSet<BnaCurriculumUpdate>();
            BnaExamMarks = new HashSet<BnaExamMark>();

            TraineeBioDataOthers = new HashSet<TraineeBioDataOther>();

            CourseSections = new HashSet<CourseSection>(); 
        }

        public int BnaCurriculumTypeId { get; set; }
        public string CurriculumType { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BnaCurriculumUpdate> BnaCurriculumUpdates { get; set; }
        public virtual ICollection<BnaExamMark> BnaExamMarks { get; set; }

        public virtual ICollection<CourseSection> CourseSections { get; set; }

        public virtual ICollection<TraineeBioDataOther> TraineeBioDataOthers { get; set; }


    }
}
