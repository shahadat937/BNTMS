using MediatR;
using SchoolManagement.Application.DTOs.BnaExamMark;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaExamMarks.Requests.Queries
{
    public class GetExamMarkListByParametersRequest : IRequest<List<BnaExamMarkDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }  
        public int CourseDurationId { get; set; }  
        public int BnaSubjectNameId { get; set; }
        public int SubjectMarkId { get; set; }
        public bool ApproveStatus { get; set; }
    }
}

 