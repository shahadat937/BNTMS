using MediatR;
using SchoolManagement.Application.DTOs.BnaClassTest;

namespace SchoolManagement.Application.Features.BnaClassTests.Requests.Queries
{
    public class GetBnaClassTestDetailRequest: IRequest<BnaClassTestDto>
    {
        public int BnaClassTestId { get; set; }
    }
}
 