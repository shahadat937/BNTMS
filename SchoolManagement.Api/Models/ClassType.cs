using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ClassType
    {
        public ClassType()
        {
            ClassRoutines = new HashSet<ClassRoutine>();
        }

        public int ClassTypeId { get; set; }
        public string ClassTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ClassRoutine> ClassRoutines { get; set; }
    }
}
