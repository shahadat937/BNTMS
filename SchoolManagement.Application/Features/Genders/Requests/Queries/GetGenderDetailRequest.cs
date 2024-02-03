using SchoolManagement.Application.DTOs.Gender;
using MediatR;

namespace SchoolManagement.Application.Features.Genders.Requests.Queries
{
    public class GetGenderDetailRequest : IRequest<GenderDto>
    {
        public int GenderId { get; set; }
    }
}
