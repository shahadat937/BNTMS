using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetApproveSubjectNameByParametersFromClassRoutineRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }  
        public int CourseDurationId { get; set; } 
    }
}

  