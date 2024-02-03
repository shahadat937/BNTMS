using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetSelectedCourseDurationByParametersFromNewEntryEvaluationRequest : IRequest<int>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }  
        //public int CourseModuleId { get; set; }
        //public int WeekNameId { get; set; }
    }
}

 