using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CountryGroup;
using SchoolManagement.Application.Features.CountryGroups.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CountryGroups.Handlers.Queries
{
    public class GetCountryGroupDetailRequestHandler : IRequestHandler<GetCountryGroupDetailRequest, CountryGroupDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CountryGroup> _CountryGroupRepository;
        public GetCountryGroupDetailRequestHandler(ISchoolManagementRepository<CountryGroup> CountryGroupRepository, IMapper mapper)
        {
            _CountryGroupRepository = CountryGroupRepository;
            _mapper = mapper;
        }
        public async Task<CountryGroupDto> Handle(GetCountryGroupDetailRequest request, CancellationToken cancellationToken)
        {
            var CountryGroup = await _CountryGroupRepository.Get(request.CountryGroupId);
            return _mapper.Map<CountryGroupDto>(CountryGroup);
        }
    }
}
