using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.BnaExamMark.converter;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.BnaExamMark
{ 
    public class JcoExamMarkListDto
    {
        public int? Ser { get; set; }
        public string? Ono { get; set; }
        public string? Name { get; set; }
        public string? Rank { get; set; }
        public string? IndexNo { get; set; } 
        public string? NoOfAttempt { get; set; } 
        public string? Billet { get; set; } 
        public string? SaylorBranch { get; set; } 
        public string? SaylorSubBranch { get; set; } 
        public string? SubjectName { get; set; } 
        public string? TotalObtained { get; set; } 
        public string? TotalMark { get; set; } 
        public string? Percentage { get; set; } 
        public string? PassStatus { get; set; }         

    }
}
