using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class GameSport
    {
        public int GameSportId { get; set; }
        public int TraineeId { get; set; }
        public int? GameId { get; set; }
        public string LevelOfParticipation { get; set; }
        public string Performance { get; set; }
        public string AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual Game Game { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
