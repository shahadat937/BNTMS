﻿using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class MilitaryTraining
    {
        public int MilitaryTrainingId { get; set; }
        public int? TraineeId { get; set; }
        public DateTime? DateAttended { get; set; }
        public string LocationOfTrg { get; set; }
        public string DetailsOfCourse { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
