using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.ResultStatus
{
    public interface IResultStatusDto
    {
        public int ResultStatusId { get; set; }
        public string? ResultStatusName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}
