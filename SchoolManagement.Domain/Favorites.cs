using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Favorites : BaseDomainEntity
    {
        public int FavoritesId { get; set; }
        public int? TraineeId { get; set; }
        public int? FavoritesTypeId { get; set; }
        public string? FavoritesName { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual FavoritesType? FavoritesType { get; set; }
        public virtual TraineeBioDataGeneralInfo? Trainee { get; set; }
    }
}
