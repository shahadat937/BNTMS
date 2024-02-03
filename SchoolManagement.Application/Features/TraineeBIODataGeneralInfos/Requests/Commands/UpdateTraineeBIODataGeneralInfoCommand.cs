using MediatR;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands
{
    public class UpdateTraineeBioDataGeneralInfoCommand : IRequest<Unit>
    {
        public CreateTraineeBioDataGeneralInfoDto CreateTraineeBioDataGeneralInfoDto { get; set; }

    }
}
