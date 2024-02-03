using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Handlers.Queries
{
    //public class GetTraineeVisitedAboardListByTraineeRequestHandler : IRequestHandler<GetTraineeVisitedAboardListByTraineeRequest, Unit>


    public class GetTraineeVisitedAboardListByTraineeRequestHandler : IRequestHandler<GetTraineeVisitedAboardListByTraineeRequest, List<TraineeVisitedAboardDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeVisitedAboard> _TraineeVisitedAboardRepository;
        public GetTraineeVisitedAboardListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeVisitedAboard> TraineeVisitedAboardRepository, IMapper mapper)
        {
            _TraineeVisitedAboardRepository = TraineeVisitedAboardRepository;
            _mapper = mapper;
        }
        public async Task<List<TraineeVisitedAboardDto>> Handle(GetTraineeVisitedAboardListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var TraineeVisitedAboard = _TraineeVisitedAboardRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "Country");
            return _mapper.Map<List<TraineeVisitedAboardDto>>(TraineeVisitedAboard);
        }
    }
}
