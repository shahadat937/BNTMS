using MediatR;
using SchoolManagement.Application.DTOs.Height;

namespace SchoolManagement.Application.Features.Heights.Requests.Queries
{
    public class GetHeightsDetailRequest : IRequest<HeightDto>
    {
        public int Id { get; set; }
    }
}
