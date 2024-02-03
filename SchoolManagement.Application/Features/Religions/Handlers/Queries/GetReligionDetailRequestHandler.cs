using AutoMapper;
using SchoolManagement.Application.DTOs.Religion;
using SchoolManagement.Application.Features.Religions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Religions.Handlers.Queries
{
    public class GetReligionDetailRequestHandler : IRequestHandler<GetReligionDetailRequest, ReligionDto>
    {
       // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Religion> _ReligionRepository;
        public GetReligionDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Religion> ReligionRepository, IMapper mapper)
        {
            _ReligionRepository = ReligionRepository;
            _mapper = mapper;
        }
        public async Task<ReligionDto> Handle(GetReligionDetailRequest request, CancellationToken cancellationToken)
        {
            var Religion = await _ReligionRepository.Get(request.ReligionId);
            return _mapper.Map<ReligionDto>(Religion);
        }
    }
}
