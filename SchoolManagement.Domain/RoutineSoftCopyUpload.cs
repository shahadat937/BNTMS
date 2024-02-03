using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;
 
namespace SchoolManagement.Domain
{
    public class RoutineSoftCopyUpload :BaseDomainEntity
    {
        public int RoutineSoftCopyUploadId { get; set; }
        public int CourseDurationId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public string? DocumentLink { get; set; }
        public string? DocumentName { get; set; }
        public int? Status { get; set; }
        public bool? IsApproved { get; set; }
        public bool? IsActive { get; set; }

        public virtual BaseSchoolName? BaseSchoolName { get; set; }
        public virtual CourseDuration? CourseDuration { get; set; }
    }
}
