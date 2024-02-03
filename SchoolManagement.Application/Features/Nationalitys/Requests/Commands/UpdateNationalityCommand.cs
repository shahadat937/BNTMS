using MediatR;
using SchoolManagement.Application.DTOs.Nationality;

namespace SchoolManagement.Application.Features.Nationalitys.Requests.Commands
{
    public class UpdateNationalityCommand : IRequest<Unit>
    {
        public NationalityDto NationalityDto { get; set; }
    }
}
