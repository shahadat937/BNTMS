using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Handlers.Queries
{
    public class GetTraineeVisitedAboardDetailRequestHandler : IRequestHandler<GetTraineeVisitedAboardDetailRequest, TraineeVisitedAboardDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeVisitedAboard> _TraineeVisitedAboardRepository;
        public GetTraineeVisitedAboardDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeVisitedAboard> TraineeVisitedAboardRepository, IMapper mapper)
        {
            _TraineeVisitedAboardRepository = TraineeVisitedAboardRepository;
            _mapper = mapper;
        }
        public async Task<TraineeVisitedAboardDto> Handle(GetTraineeVisitedAboardDetailRequest request, CancellationToken cancellationToken)
        {
            var TraineeVisitedAboard = await _TraineeVisitedAboardRepository.FindOneAsync(x => x.TraineeVisitedAboardId == request.TraineeVisitedAboardId, "Country");
            return _mapper.Map<TraineeVisitedAboardDto>(TraineeVisitedAboard);
        }
    }
}
