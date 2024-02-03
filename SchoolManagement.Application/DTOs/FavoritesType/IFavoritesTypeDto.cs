using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.FavoritesType
{
    public interface IFavoritesTypeDto
    {
        public int FavoritesTypeId { get; set; }
        public string FavoritesTypeName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
