using MediatR;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetTraineeBioDataGeneralInfoByTraineeId : IRequest<TraineeBioDataGeneralInfoDto>
    {
        public int TraineeId { get; set; }
    }
}
