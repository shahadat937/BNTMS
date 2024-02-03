using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Handlers.Queries
{
    public class GetTraineeBioDataGeneralInfoDetailRequestHandler : IRequestHandler<GetTraineeBioDataGeneralInfoDetailRequest, TraineeBioDataGeneralInfoDto>
    {
        
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> _TraineeBioDataGeneralInfoRepository;
        public GetTraineeBioDataGeneralInfoDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeBioDataGeneralInfo> TraineeBioDataGeneralInfoRepository, IMapper mapper)
        {
            _TraineeBioDataGeneralInfoRepository = TraineeBioDataGeneralInfoRepository;
            _mapper = mapper;
        }
        public async Task<TraineeBioDataGeneralInfoDto> Handle(GetTraineeBioDataGeneralInfoDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeBioDataGeneralInfo = await _TraineeBioDataGeneralInfoRepository.Get(request.TraineeId);
            return _mapper.Map<TraineeBioDataGeneralInfoDto>(TraineeBioDataGeneralInfo);
        }
    }
}
