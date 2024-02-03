using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Queries
{
    public class GetSelectedTraineeCourseStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
    