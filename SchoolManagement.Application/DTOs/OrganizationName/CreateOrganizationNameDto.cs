using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OrganizationName
{
    public class CreateOrganizationNameDto : IOrganizationNameDto
    {
        public int OrganizationNameId { get; set; }
        public int? ForceTypeId { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; }
    }
}
