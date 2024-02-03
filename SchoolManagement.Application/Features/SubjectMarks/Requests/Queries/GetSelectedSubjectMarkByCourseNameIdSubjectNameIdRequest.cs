using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.DTOs.SubjectMark;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetSelectedSubjectMarkByCourseNameIdSubjectNameIdRequest : IRequest<List<SubjectMarkDto>> 
    {
        public int CourseNameId { get; set; }  
        public int BnaSubjectNameId { get; set; }
    }
}

  