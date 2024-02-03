using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetSelectedRoutineIdFilterRequest : IRequest<int>
    { 
        public int BaseSchoolNameId { get; set; } 
        public int CourseNameId { get; set; }  
        public int ClassPeriodId { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseSectionId { get; set; }
        public DateTime Date { get; set; }
    }
}

 