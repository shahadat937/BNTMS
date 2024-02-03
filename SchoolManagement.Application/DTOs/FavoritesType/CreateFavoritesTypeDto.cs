using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FavoritesType
{
    public class CreateFavoritesTypeDto : IFavoritesTypeDto
    {
        public int FavoritesTypeId { get; set; }
        public string FavoritesTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
