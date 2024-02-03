using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.Games
{
    public interface IGameDto
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 