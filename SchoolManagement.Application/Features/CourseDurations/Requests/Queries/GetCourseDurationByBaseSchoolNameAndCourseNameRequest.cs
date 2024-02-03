using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetCourseDurationByBaseSchoolNameAndCourseNameRequest : IRequest<int>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }  
    }
}

 