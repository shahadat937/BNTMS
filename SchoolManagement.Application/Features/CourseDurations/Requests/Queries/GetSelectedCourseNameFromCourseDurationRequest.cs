using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseDurations.Requests.Queries
{
    public class GetSelectedCourseNameFromCourseDurationRequest : IRequest<List<SelectedModel>>
    {
       // public int AllowanceCategoryId { get; set; }
    }
}  
  