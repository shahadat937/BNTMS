using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class RelationType
    {
        public RelationType()
        {
            FamilyInfos = new HashSet<FamilyInfo>();
            FamilyNominations = new HashSet<FamilyNomination>();
            MigrationDocuments = new HashSet<MigrationDocument>();
            ParentRelatives = new HashSet<ParentRelative>();
        }

        public int RelationTypeId { get; set; }
        public string RelationTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<FamilyInfo> FamilyInfos { get; set; }
        public virtual ICollection<FamilyNomination> FamilyNominations { get; set; }
        public virtual ICollection<MigrationDocument> MigrationDocuments { get; set; }
        public virtual ICollection<ParentRelative> ParentRelatives { get; set; }
    }
}
