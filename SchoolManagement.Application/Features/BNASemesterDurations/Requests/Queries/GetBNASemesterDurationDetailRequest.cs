using MediatR;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;
 
namespace SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Queries
{
    public class GetBnaSemesterDurationDetailRequest : IRequest<BnaSemesterDurationDto> 
    {
        public int Id { get; set; } 
    }
} 
 