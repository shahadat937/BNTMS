using MediatR;
using SchoolManagement.Application.DTOs.NewEntryEvaluation;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Queries
{
    public class GetNewEntryEvaluationListBySchoolAndCourseIdRequest : IRequest<List<NewEntryEvaluationDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }  
       
    }
}

 