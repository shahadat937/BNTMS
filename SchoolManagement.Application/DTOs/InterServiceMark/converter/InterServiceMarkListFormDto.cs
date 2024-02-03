using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.DTOs.Common;

namespace SchoolManagement.Application.DTOs.InterServiceMark.converter
{ 
    public class InterServiceMarkListFormDto
    {
       // public TraineeListForm TraineeListForm { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? TraineeId { get; set; }
        public int? TraineeNominationId { get; set; }
        public string? TraineePNo { get; set; }
        public string? TraineeName { get; set; }
        public string? RankPosition { get; set; }
        public string? CoursePosition { get; set; }
        public string? ObtaintMark { get; set; }
        public IFormCollection? Doc { get; set; }
        //    public string? Image { get; set; }
        public string? Remarks { get; set; }
    }
}
