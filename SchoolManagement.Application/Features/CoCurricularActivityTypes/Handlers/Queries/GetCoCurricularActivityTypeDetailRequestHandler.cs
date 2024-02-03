using AutoMapper;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Handlers.Queries
{
    public class GetCoCurricularActivityTypeDetailRequestHandler : IRequestHandler<GetCoCurricularActivityTypeDetailRequest, CoCurricularActivityTypeDto>
    {
       // private readonly ICoCurricularActivityTypeRepository _CoCurricularActivityTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivityType> _CoCurricularActivityTypeRepository;
        public GetCoCurricularActivityTypeDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivityType>  CoCurricularActivityTypeRepository, IMapper mapper)
        {
            _CoCurricularActivityTypeRepository = CoCurricularActivityTypeRepository;
            _mapper = mapper;
        }
        public async Task<CoCurricularActivityTypeDto> Handle(GetCoCurricularActivityTypeDetailRequest request, CancellationToken cancellationToken)
        {
            var CoCurricularActivityType = await _CoCurricularActivityTypeRepository.Get(request.CoCurricularActivityTypeId);
            return _mapper.Map<CoCurricularActivityTypeDto>(CoCurricularActivityType);
        }
    }
}
