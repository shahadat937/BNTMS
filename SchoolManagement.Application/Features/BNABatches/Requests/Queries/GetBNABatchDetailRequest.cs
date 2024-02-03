using MediatR;
using SchoolManagement.Application.DTOs.BnaBatch;

namespace SchoolManagement.Application.Features.BnaBatches.Requests.Queries
{
    public class GetBnaBatchDetailRequest : IRequest<BnaBatchDto>
    {
        public int BnaBatchId { get; set; }
    }
}
 