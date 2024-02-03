using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class InterServiceCourseDocType
    {
        public InterServiceCourseDocType()
        {
            Documents = new HashSet<Document>();
            InterServiceOthersDocs = new HashSet<InterServiceOthersDoc>();
        }

        public int InterServiceCourseDocTypeId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Document> Documents { get; set; }
        public virtual ICollection<InterServiceOthersDoc> InterServiceOthersDocs { get; set; }
    }
}
