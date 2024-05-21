using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseLevels.Requests.Queries
{
    public class GetSelectedCourseLevelRequest : IRequest<List<SelectedModel>>
    {
    }
} 
      