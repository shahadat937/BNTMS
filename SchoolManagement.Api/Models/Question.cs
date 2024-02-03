using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Question
    {
        public int QuestionId { get; set; }
        public int? TraineeId { get; set; }
        public int? QuestionTypeId { get; set; }
        public string Answer { get; set; }
        public string AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual QuestionType QuestionType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
