using MediatR;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.Responses;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Commands
{
    public class CreateTraineeBioDataGeneralInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeBioDataGeneralInfoDto TraineeBioDataGeneralInfoDto { get; set; }

    }
}
