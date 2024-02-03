using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Nationality;
using SchoolManagement.Application.Features.Nationalitys.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Nationalitys.Handlers.Queries
{
    public class GetNationalityDetailRequestHandler : IRequestHandler<GetNationalityDetailRequest, NationalityDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Nationality> _NationalityRepository;
        public GetNationalityDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Nationality> NationalityRepository, IMapper mapper)
        {
            _NationalityRepository = NationalityRepository;
            _mapper = mapper;
        }
        public async Task<NationalityDto> Handle(GetNationalityDetailRequest request, CancellationToken cancellationToken)
        {
            var Nationality = await _NationalityRepository.Get(request.NationalityId);
            return _mapper.Map<NationalityDto>(Nationality);
        }
    }
}
