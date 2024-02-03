using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTestType;

namespace SchoolManagement.Application.Features.BnaClassTestTypes.Requests.Queries
{
    public class GetBnaClassTestTypeDetailRequest: IRequest<BnaClassTestTypeDto>
    {
        public int BnaClassTestTypeId { get; set; }
    }
}
 