﻿using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class NewAtempt
    {
        public NewAtempt()
        {
            TraineeNominations = new HashSet<TraineeNomination>();
        }

        public int NewAtemptId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<TraineeNomination> TraineeNominations { get; set; }
    }
}
