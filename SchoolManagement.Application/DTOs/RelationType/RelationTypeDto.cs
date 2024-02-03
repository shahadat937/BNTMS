using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.RelationType
{
    public class RelationTypeDto : IRelationTypeDto
    {
        public int RelationTypeId { get; set; }
        public string RelationTypeName { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
