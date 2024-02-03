using SchoolManagement.Application.DTOs.Gender;
using MediatR;

namespace SchoolManagement.Application.Features.Genders.Requests.Commands
{
    public class UpdateGenderCommand : IRequest<Unit>
    {
        public GenderDto GenderDto { get; set; }

    }
}
