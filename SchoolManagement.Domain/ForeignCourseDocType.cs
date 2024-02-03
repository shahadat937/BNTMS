using SchoolManagement.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Domain
{
    public class ForeignCourseDocType:BaseDomainEntity
    {
        public ForeignCourseDocType()
        {
            ForeignCourseOthersDocuments = new HashSet<ForeignCourseOthersDocument>();
        }
        public int ForeignCourseDocTypeId { get; set; }
        public string? Name { get; set; }
        public string? Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<ForeignCourseOthersDocument> ForeignCourseOthersDocuments { get; set; }
    }
}
