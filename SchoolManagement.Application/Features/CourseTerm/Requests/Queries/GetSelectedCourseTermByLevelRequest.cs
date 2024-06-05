using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTerms.Requests.Queries
{
    public class GetSelectedCourseTermByLevelRequest : IRequest<List<SelectedModel>>
    {
         public int CourseLevelId { get; set; }
    }
} 
      