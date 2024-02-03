using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries
{
    public class GetTraineeAssignmentSubmitListRequest : IRequest<PagedResult<TraineeAssignmentSubmitDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
