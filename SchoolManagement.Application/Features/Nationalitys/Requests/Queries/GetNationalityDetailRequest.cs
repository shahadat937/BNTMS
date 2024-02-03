using MediatR;
using SchoolManagement.Application.DTOs.Nationality;

namespace SchoolManagement.Application.Features.Nationalitys.Requests.Queries
{
    public class GetNationalityDetailRequest : IRequest<NationalityDto>
    {
        public int NationalityId { get; set; }
    }
}
