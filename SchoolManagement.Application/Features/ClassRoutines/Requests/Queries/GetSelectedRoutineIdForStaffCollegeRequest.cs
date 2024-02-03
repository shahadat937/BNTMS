using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetSelectedRoutineIdForStaffCollegeRequest : IRequest<int>
    {
        public int BnaSubjectNameId { get; set; }
        public int CourseNameId { get; set; }  
        public int CourseDurationId { get; set; } 
    }
} 

 