using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain
{
    public class ForeignCourseOthersDocument:BaseDomainEntity
    {
        public int ForeignCourseOthersDocumentId { get; set; }
        public int CourseDurationId { get; set; }
        public int? TraineeId { get; set; } 
        public int? CourseNameId { get; set; }
        public int? ForeignCourseDocTypeId { get; set; }
        public int? Status { get; set; }
        public string? FileUpload { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }       
        public bool IsActive { get; set; }
        public virtual CourseDuration CourseDuration { get; set; } = null!;
        public virtual CourseName? CourseName { get; set; }
        public virtual ForeignCourseDocType? ForeignCourseDocType { get; set; }

        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
