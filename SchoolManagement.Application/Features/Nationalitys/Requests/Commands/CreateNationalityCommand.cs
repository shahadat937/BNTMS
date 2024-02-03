using MediatR;
using SchoolManagement.Application.DTOs.Nationality;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.Nationalitys.Requests.Commands
{
    public class CreateNationalityCommand : IRequest<BaseCommandResponse>
    {
        public CreateNationalityDto NationalityDto { get; set; }
    }
}
