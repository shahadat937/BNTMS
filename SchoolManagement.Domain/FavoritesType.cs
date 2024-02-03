using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class FavoritesType : BaseDomainEntity
    {
        public FavoritesType()
        {
            Favorites = new HashSet<Favorites>();
        }

        public int FavoritesTypeId { get; set; }
        public string FavoritesTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
    }
}
