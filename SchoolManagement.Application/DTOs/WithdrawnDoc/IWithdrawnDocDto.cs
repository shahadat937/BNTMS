using System;

namespace SchoolManagement.Application.DTOs.WithdrawnDoc
{
    public interface IWithdrawnDocDto
    {
        public int WithdrawnDocId { get; set; }
        public string? WithdrawnDocName { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
 