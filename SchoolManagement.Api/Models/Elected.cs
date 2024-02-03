using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Elected
    {
        public Elected()
        {
            Elections = new HashSet<Election>();
        }

        public int ElectedId { get; set; }
        public string ElectedType { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Election> Elections { get; set; }
    }
}
