﻿namespace SchoolManagement.Application.DTOs.AllowancePercentage
{
    public class AllowancePercentageDto: IAllowancePercentageDto
    {
        public int AllowancePercentageId { get; set; }
        public string? AllowanceName { get; set; }
        public string? Percentage { get; set; }
        public int? DisplayPriority { get; set; }
        public bool IsActive { get; set; }
    }
}
