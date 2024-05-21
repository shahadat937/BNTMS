using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseTerms.Requests.Queries
{
    public class GetSelectedCourseTermRequest : IRequest<List<SelectedModel>>
    {
    }
} 
      