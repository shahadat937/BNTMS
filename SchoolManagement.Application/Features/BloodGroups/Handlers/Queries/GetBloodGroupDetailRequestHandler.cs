using AutoMapper;
using SchoolManagement.Application.DTOs.BloodGroup;
using SchoolManagement.Application.Features.BloodGroups.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BloodGroups.Handlers.Queries
{
    public class GetBloodGroupDetailRequestHandler : IRequestHandler<GetBloodGroupDetailRequest, BloodGroupDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BloodGroup> _BloodGroupRepository;
        public GetBloodGroupDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BloodGroup> BloodGroupRepository, IMapper mapper)
        {
            _BloodGroupRepository = BloodGroupRepository;
            _mapper = mapper;
        }
        public async Task<BloodGroupDto> Handle(GetBloodGroupDetailRequest request, CancellationToken cancellationToken)
        {
            var BloodGroup = await _BloodGroupRepository.Get(request.BloodGroupId);
            return _mapper.Map<BloodGroupDto>(BloodGroup);
        }
    }
}
