using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDriving;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Handlers.Queries
{
    public class GetSwimmingDrivingListByTraineeRequestHandler : IRequestHandler<GetSwimmingDrivingListByTraineeRequest, List<SwimmingDrivingDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDriving> _SwimmingDrivingRepository;
        public GetSwimmingDrivingListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDriving> SwimmingDrivingRepository, IMapper mapper)
        {
            _SwimmingDrivingRepository = SwimmingDrivingRepository;
            _mapper = mapper;
        }
        public async Task<List<SwimmingDrivingDto>> Handle(GetSwimmingDrivingListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var SwimmingDriving = _SwimmingDrivingRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId);
            return _mapper.Map<List<SwimmingDrivingDto>>(SwimmingDriving);
        }
    }
    
}
