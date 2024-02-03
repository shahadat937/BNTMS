using AutoMapper;
using SchoolManagement.Application.DTOs.CoCurricularActivity;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoCurricularActivities.Handlers.Queries
{
    //public class GetCoCurricularActivityListByTraineeRequestHandler : IRequestHandler<GetCoCurricularActivityListByTraineeRequest, Unit>


    public class GetCoCurricularActivityListByTraineeRequestHandler : IRequestHandler<GetCoCurricularActivityListByTraineeRequest, List<CoCurricularActivityDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivity> _CoCurricularActivityRepository;
        public GetCoCurricularActivityListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivity> CoCurricularActivityRepository, IMapper mapper)
        {
            _CoCurricularActivityRepository = CoCurricularActivityRepository;
            _mapper = mapper;
        }
        public async Task<List<CoCurricularActivityDto>> Handle(GetCoCurricularActivityListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var CoCurricularActivity = _CoCurricularActivityRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "CoCurricularActivityType");
            return _mapper.Map<List<CoCurricularActivityDto>>(CoCurricularActivity);
        }
    }
}
