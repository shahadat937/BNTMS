using AutoMapper;
using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ParentRelatives.Handlers.Queries
{
    public class GetParentRelativeDetailRequestHandler : IRequestHandler<GetParentRelativeDetailRequest, ParentRelativeDto>
    {
       // private readonly IParentRelativeRepository _ParentRelativeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ParentRelative> _ParentRelativeRepository;
        public GetParentRelativeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ParentRelative>  ParentRelativeRepository, IMapper mapper)
        {
            _ParentRelativeRepository = ParentRelativeRepository;
            _mapper = mapper;
        }
        public async Task<ParentRelativeDto> Handle(GetParentRelativeDetailRequest request, CancellationToken cancellationToken)
        {
            var ParentRelative = await _ParentRelativeRepository.FindOneAsync(x => x.ParentRelativeId == request.ParentRelativeId, "RelationType", "MaritalStatus", "Nationality", "PreviousOccupation", "Religion", "Caste", "Occupation", "SecondNationality", "Division", "District", "Thana", "DefenseType", "Rank", "DeadStatusNavigation");
            return _mapper.Map<ParentRelativeDto>(ParentRelative);
        }
    }
}
