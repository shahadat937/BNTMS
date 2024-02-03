using AutoMapper;
using SchoolManagement.Application.DTOs.CoCurricularActivity;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Handlers.Queries
{
    public class GetCoCurricularActivityDetailRequestHandler : IRequestHandler<GetCoCurricularActivityDetailRequest, CoCurricularActivityDto>
    {
       // private readonly ICoCurricularActivityRepository _CoCurricularActivityRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivity> _CoCurricularActivityRepository;
        public GetCoCurricularActivityDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivity>  CoCurricularActivityRepository, IMapper mapper)
        {
            _CoCurricularActivityRepository = CoCurricularActivityRepository;
            _mapper = mapper;
        }
        public async Task<CoCurricularActivityDto> Handle(GetCoCurricularActivityDetailRequest request, CancellationToken cancellationToken)
        {
            var CoCurricularActivity = await _CoCurricularActivityRepository.FindOneAsync(x => x.CoCurricularActivityId == request.CoCurricularActivityId, "CoCurricularActivityType");
            return _mapper.Map<CoCurricularActivityDto>(CoCurricularActivity);
        }
    }
}
