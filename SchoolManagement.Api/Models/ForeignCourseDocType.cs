﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ForeignCourseDocType
    {
        public ForeignCourseDocType()
        {
            ForeignCourseOthersDocuments = new HashSet<ForeignCourseOthersDocument>();
        }

        public int ForeignCourseDocTypeId { get; set; }
        public string Name { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ForeignCourseOthersDocument> ForeignCourseOthersDocuments { get; set; }
    }
}
