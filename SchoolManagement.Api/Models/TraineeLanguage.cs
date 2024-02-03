using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class TraineeLanguage
    {
        public int TraineeLanguageId { get; set; }
        public int TraineeId { get; set; }
        public int LanguageId { get; set; }
        public string Speaking { get; set; }
        public string Writing { get; set; }
        public string Reading { get; set; }
        public string AdditionalInformation { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Language Language { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
