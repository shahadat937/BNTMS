using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class GameSport : BaseDomainEntity
    {
        public int GameSportId { get; set; }
        public int TraineeId { get; set; }
        public int? GameId { get; set; }
        public string? LevelOfParticipation { get; set; }
        public string? Performance { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual Game Game { get; set; } = null!;
        public virtual TraineeBioDataGeneralInfo Trainee { get; set; } = null!;

    }
}
