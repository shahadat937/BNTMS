using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using MediatR;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Queries
{
    public class GetBnaCurriculumUpdateDetailRequest : IRequest<BnaCurriculumUpdateDto>
    {
        public int BnaCurriculumUpdateId { get; set; }
    }
}
