using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.QuestionType
{
    public interface IQuestionTypeDto
    {
        public int QuestionTypeId { get; set; }
        public string Question { get; set; } 
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
