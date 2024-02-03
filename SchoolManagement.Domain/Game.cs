using SchoolManagement.Domain.Common;

namespace SchoolManagement.Domain
{
    public class Game : BaseDomainEntity
    {
        public Game()
        {
            GameSports = new HashSet<GameSport>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GameSport> GameSports { get; set; }
    }
}
