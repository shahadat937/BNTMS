﻿namespace SchoolManagement.Application.DTOs.WithdrawnType
{
    public class CreateWithdrawnTypeDto : IWithdrawnTypeDto 
    {
        public int WithdrawnTypeId { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 