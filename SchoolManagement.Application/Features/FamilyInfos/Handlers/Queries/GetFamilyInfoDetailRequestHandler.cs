using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Queries
{
    public class GetFamilyInfoDetailRequestHandler : IRequestHandler<GetFamilyInfoDetailRequest, FamilyInfoDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<FamilyInfo> _FamilyInfoRepository;
        public GetFamilyInfoDetailRequestHandler(ISchoolManagementRepository<FamilyInfo> FamilyInfoRepository, IMapper mapper)
        {
            _FamilyInfoRepository = FamilyInfoRepository;
            _mapper = mapper;
        }
        public async Task<FamilyInfoDto> Handle(GetFamilyInfoDetailRequest request, CancellationToken cancellationToken)
        {
            //var FamilyInfo = await _FamilyInfoRepository.Get(request.FamilyInfoId);
            var FamilyInfo = _FamilyInfoRepository.FinedOneInclude(x => x.FamilyInfoId == request.FamilyInfoId, "Trainee");
            return _mapper.Map<FamilyInfoDto>(FamilyInfo);
        }
    }
}
