using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.WeekNames.Requests.Queries
{
    public class GetSelectedWeekNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
