using MediatR;
using SchoolManagement.Application.DTOs.GrandFather;

namespace SchoolManagement.Application.Features.GrandFathers.Requests.Commands
{
    public class UpdateGrandFatherCommand : IRequest<Unit>
    {
        public GrandFatherDto GrandFatherDto { get; set; } 

    }
}
