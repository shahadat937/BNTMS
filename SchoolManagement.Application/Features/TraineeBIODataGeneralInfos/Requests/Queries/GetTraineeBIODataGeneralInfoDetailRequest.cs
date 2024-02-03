using MediatR;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetTraineeBioDataGeneralInfoDetailRequest : IRequest<TraineeBioDataGeneralInfoDto>
    {
        public int TraineeId { get; set; }
    }
}
