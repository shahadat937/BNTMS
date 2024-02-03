using MediatR;
using SchoolManagement.Application.DTOs.TdecGroupResult;

namespace SchoolManagement.Application.Features.TdecGroupResults.Requests.Queries
{
    public class GetTdecGroupResultDetailRequest : IRequest<TdecGroupResultDto>
    {
        public int TdecGroupResultId { get; set; }
    }
}
