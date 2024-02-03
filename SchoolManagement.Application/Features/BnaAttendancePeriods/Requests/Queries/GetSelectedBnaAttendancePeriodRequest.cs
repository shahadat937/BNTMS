using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Queries
{
    public class GetSelectedBnaAttendancePeriodRequest : IRequest<List<SelectedModel>>
    {
    }
}
  