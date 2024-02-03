using SchoolManagement.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.CodeValues
{
    public class FavoritesDto : IFavoritesDto  
    {


        public int FavoritesId { get; set; }
        public int? TraineeId { get; set; }
        public int? FavoritesTypeId { get; set; }
        public string? FavoritesName { get; set; }
        public string? AdditionalInformation { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

        public string? FavoritesTypeName { get; set; }
    }
}

