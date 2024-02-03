﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class ForceType
    {
        public ForceType()
        {
            BaseNames = new HashSet<BaseName>();
            OrganizationNames = new HashSet<OrganizationName>();
        }

        public int ForceTypeId { get; set; }
        public string ForceTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<BaseName> BaseNames { get; set; }
        public virtual ICollection<OrganizationName> OrganizationNames { get; set; }
    }
}
