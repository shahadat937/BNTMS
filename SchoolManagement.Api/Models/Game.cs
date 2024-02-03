using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class Game
    {
        public Game()
        {
            GameSports = new HashSet<GameSport>();
        }

        public int GameId { get; set; }
        public string GameName { get; set; }
        public int? MenuPosition { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool IsActive { get; set; }

        public virtual ICollection<GameSport> GameSports { get; set; }
    }
}
