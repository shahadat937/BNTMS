using MediatR;
using SchoolManagement.Application.DTOs.Height;

namespace SchoolManagement.Application.Features.Heights.Requests.Commands
{
    public class UpdateHeightsCommand : IRequest<Unit> 
    { 
        public HeightDto HeightDto { get; set; }   
    }
}
