using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Occupation;
using SchoolManagement.Application.Features.Occupations.Requests.Queries;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Occupations.Handlers.Queries
{
    public class GetOccupationDetailRequestHandler : IRequestHandler<GetOccupationDetailRequest, OccupationDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Occupation> _OccupationRepository;
        public GetOccupationDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Occupation> OccupationRepository, IMapper mapper)
        {
            _OccupationRepository = OccupationRepository;
            _mapper = mapper;
        }
        public async Task<OccupationDto> Handle(GetOccupationDetailRequest request, CancellationToken cancellationToken)
        {
            var Occupation = await _OccupationRepository.Get(request.OccupationId);
            return _mapper.Map<OccupationDto>(Occupation);
        }
    }
}
