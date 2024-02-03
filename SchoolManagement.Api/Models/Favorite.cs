using SchoolManagement.Domain;
using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Favorite
    {
        public int FavoritesId { get; set; }
        public int? TraineeId { get; set; }
        public int? FavoritesTypeId { get; set; }
        public string FavoritesName { get; set; }
        public string AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual FavoritesType FavoritesType { get; set; }
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; }
    }
}
