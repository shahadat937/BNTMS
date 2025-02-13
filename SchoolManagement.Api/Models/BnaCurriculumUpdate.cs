﻿using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class BnaCurriculumUpdate
    {
        public int BnaCurriculumUpdateId { get; set; }
        public int BnaBatchId { get; set; }
        public int BnaSemesterId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaCurriculumTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual BnaCurriculumType BnaCurriculumType { get; set; }
        public virtual BnaSemester BnaSemester { get; set; }
        public virtual BnaSemesterDuration BnaSemesterDuration { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
