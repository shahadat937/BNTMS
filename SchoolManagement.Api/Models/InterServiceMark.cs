﻿using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class InterServiceMark
    {
        public int InterServiceMarkId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? CountryId { get; set; }
        public int? OrganizationNameId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public string CoursePosition { get; set; }
        public string ObtaintMark { get; set; }
        public string Doc { get; set; }
        public string Remarks { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Country Country { get; set; }
        public virtual CourseDuration CourseDuration { get; set; }
        public virtual CourseName CourseName { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual OrganizationName OrganizationName { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
        public virtual TraineeNomination TraineeNomination { get; set; }
    }
}
