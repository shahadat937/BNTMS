using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.QuestionType
{
    public class CreateQuestionTypeDto : IQuestionTypeDto
    {
        public int QuestionTypeId { get; set; }
        public string Question { get; set; } = null!;
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
