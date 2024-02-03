using SchoolManagement.Application.DTOs.Gender;
using SchoolManagement.Application.Responses;
using MediatR;

namespace SchoolManagement.Application.Features.Genders.Requests.Commands
{
    public class CreateGenderCommand : IRequest<BaseCommandResponse>
    {
        public CreateGenderDto GenderDto { get; set; }

    }
}
