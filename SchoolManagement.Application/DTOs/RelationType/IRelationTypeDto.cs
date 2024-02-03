using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.RelationType
{
    public interface IRelationTypeDto
    {
        public int RelationTypeId { get; set; }
        public string RelationTypeName { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
