using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CodeValues 
{
    public interface IFavoritesDto 
    {
        public int FavoritesId { get; set; }
        public int? TraineeId { get; set; }
        public int? FavoritesTypeId { get; set; }
        public string? FavoritesName { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 