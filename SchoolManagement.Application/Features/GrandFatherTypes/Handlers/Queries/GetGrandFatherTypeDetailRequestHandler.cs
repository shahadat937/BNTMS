using AutoMapper;
using SchoolManagement.Application.DTOs.GrandFatherType;
using SchoolManagement.Application.Features.GrandFatherTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GrandFatherTypes.Handlers.Queries
{
    public class GetGrandFatherTypeDetailRequestHandler : IRequestHandler<GetGrandFatherTypeDetailRequest, GrandFatherTypeDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.GrandFatherType> _GrandFatherTypeRepository;
        public GetGrandFatherTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.GrandFatherType> GrandFatherTypeRepository, IMapper mapper)
        {
            _GrandFatherTypeRepository = GrandFatherTypeRepository;
            _mapper = mapper;
        }
        public async Task<GrandFatherTypeDto> Handle(GetGrandFatherTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var GrandFatherType = await _GrandFatherTypeRepository.Get(request.GrandfatherTypeId);
            return _mapper.Map<GrandFatherTypeDto>(GrandFatherType);
        }
    }
}
