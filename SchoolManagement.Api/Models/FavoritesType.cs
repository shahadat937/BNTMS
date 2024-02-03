using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class FavoritesType
    {
        public FavoritesType()
        {
            Favorites = new HashSet<Favorite>();
        }

        public int FavoritesTypeId { get; set; }
        public string FavoritesTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Favorite> Favorites { get; set; }
    }
}
