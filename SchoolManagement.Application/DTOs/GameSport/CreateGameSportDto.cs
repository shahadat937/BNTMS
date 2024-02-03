using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.GameSport
{
    public class CreateGameSportDto : IGameSportDto
    {
        public int GameSportId { get; set; }
        public int TraineeId { get; set; }
        public int? GameId { get; set; }
        public string? LevelOfParticipation { get; set; }
        public string? Performance { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
