using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.InterServiceMark.converter;
using SchoolManagement.Application.DTOs.Common;
using Microsoft.AspNetCore.Http;

namespace SchoolManagement.Application.DTOs.InterServiceMark
{ 
    public class InterServiceMarkListDto
    {
        public int InterServiceMarkId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? OrganizationNameId { get; set; }
        public int? CourseTypeId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; }
        public string? CoursePosition { get; set; }
        public string? ObtaintMark { get; set; }
        public string? Remarks { get; set; } 
        public IList<InterServiceMarkListFormDto> TraineeListForm { get; set; } = new List<InterServiceMarkListFormDto>();
        public bool? IsActive { get; set; }
        public string? Pno { get; set; } 


        //public int InterServiceMarkId { get; set; }
        //public int? CourseDurationId { get; set; }
        //public int? CourseNameId { get; set; }
        //public int? CountryId { get; set; }
        //public int? OrganizationNameId { get; set; }
        //public int? CourseTypeId { get; set; }
        //public int? TraineeNominationId { get; set; }
        //public int? TraineeId { get; set; }
        //public string? TraineeName { get; set; }
        //public string? TraineePNo { get; set; }
        //public string? RankPosition { get; set; }
        //public string? CoursePosition { get; set; }
        //public string? ObtaintMark { get; set; }
        //public string? Image { get; set; }
        ////public IFormFile? Doc { get; set; }
        //public string? Remarks { get; set; }
        //public bool IsActive { get; set; }
        ////public string? Pno { get; set; }
        //public List<InterServiceMarkListFormDto> traineeListForm { get; set; }


    }
}
