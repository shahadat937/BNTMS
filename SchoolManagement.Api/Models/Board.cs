using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Board
    {
        public Board()
        {
            EducationalQualifications = new HashSet<EducationalQualification>();
        }

        public int BoardId { get; set; }
        public string BoardName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }
    }
}
