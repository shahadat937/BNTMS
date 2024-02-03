using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AdminAuthority;
using SchoolManagement.Application.Features.AdminAuthoritys.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AdminAuthoritys.Handlers.Queries
{
    public class GetAdminAuthorityDetailRequestHandler : IRequestHandler<GetAdminAuthorityDetailRequest, AdminAuthorityDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<AdminAuthority> _AdminAuthorityRepository;
        public GetAdminAuthorityDetailRequestHandler(ISchoolManagementRepository<AdminAuthority> AdminAuthorityRepository, IMapper mapper)
        {
            _AdminAuthorityRepository = AdminAuthorityRepository;
            _mapper = mapper;
        }
        public async Task<AdminAuthorityDto> Handle(GetAdminAuthorityDetailRequest request, CancellationToken cancellationToken)
        {
            var AdminAuthority = await _AdminAuthorityRepository.Get(request.AdminAuthorityId);
            return _mapper.Map<AdminAuthorityDto>(AdminAuthority);
        }
    }
}
