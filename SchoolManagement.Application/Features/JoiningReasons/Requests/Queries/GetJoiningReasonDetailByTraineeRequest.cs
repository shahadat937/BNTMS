using SchoolManagement.Application.DTOs.JoiningReasons;
using MediatR;

namespace SchoolManagement.Application.Features.JoiningReasons.Requests.Queries
{
    public class GetJoiningReasonDetailByTraineeRequest : IRequest<JoiningReasonDto>
    {
        public int Traineeid { get; set; }
    }
}
