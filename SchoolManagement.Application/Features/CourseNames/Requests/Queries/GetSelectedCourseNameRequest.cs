using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseNames.Requests.Queries
{
    public class GetSelectedCourseNameRequest : IRequest<List<SelectedModel>>
    {
    }
} 
 