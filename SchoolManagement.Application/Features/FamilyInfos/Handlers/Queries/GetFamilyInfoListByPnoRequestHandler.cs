using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Queries
{
    public class GetFamilyInfoListByPnoRequestHandler : IRequestHandler<GetFamilyInfoListByPnoRequest, List<FamilyInfoDto>>
    {
        private readonly ISchoolManagementRepository<FamilyInfo> _FamilyInfoRepository;
        private readonly IMapper _mapper;

        public GetFamilyInfoListByPnoRequestHandler(ISchoolManagementRepository<FamilyInfo> FamilyInfoRepository, IMapper mapper)
        {
            _FamilyInfoRepository = FamilyInfoRepository;
            _mapper = mapper;
        }
         
        public async Task<List<FamilyInfoDto>> Handle(GetFamilyInfoListByPnoRequest request, CancellationToken cancellationToken)
        {
            ICollection<FamilyInfo> familyInfos = _FamilyInfoRepository.FilterWithInclude(x=>x.TraineeId == request.TraineeId, "Trainee", "RelationType", "Trainee.Rank").ToList();
            
            var FamilyInfoDtos = _mapper.Map<List<FamilyInfoDto>>(familyInfos);
            return FamilyInfoDtos; 
        }
    }
}
