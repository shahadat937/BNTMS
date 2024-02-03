using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class AllowancePercentage
    {
        public AllowancePercentage()
        {
            AllowanceCategories = new HashSet<AllowanceCategory>();
        }

        public int AllowancePercentageId { get; set; }
        public string AllowanceName { get; set; }
        public string Percentage { get; set; }
        public int? DisplayPriority { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<AllowanceCategory> AllowanceCategories { get; set; }
    }
}
