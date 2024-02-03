using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.OrganizationName;
using SchoolManagement.Application.Features.OrganizationNames.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OrganizationNames.Handlers.Queries
{
    public class GetOrganizationNameDetailRequestHandler : IRequestHandler<GetOrganizationNameDetailRequest, OrganizationNameDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.OrganizationName> _OrganizationNameRepository;
        public GetOrganizationNameDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.OrganizationName> OrganizationNameRepository, IMapper mapper)
        {
            _OrganizationNameRepository = OrganizationNameRepository;
            _mapper = mapper;
        }
        public async Task<OrganizationNameDto> Handle(GetOrganizationNameDetailRequest request, CancellationToken cancellationToken)
        {
            var OrganizationName = await _OrganizationNameRepository.Get(request.OrganizationNameId);
            return _mapper.Map<OrganizationNameDto>(OrganizationName);
        }
    }
}
