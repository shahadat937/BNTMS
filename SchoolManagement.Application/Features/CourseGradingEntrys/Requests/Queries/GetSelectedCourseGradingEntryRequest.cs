using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries
{
    public class GetSelectedCourseGradingEntryRequest : IRequest<List<SelectedModel>>
    {
    }
}
