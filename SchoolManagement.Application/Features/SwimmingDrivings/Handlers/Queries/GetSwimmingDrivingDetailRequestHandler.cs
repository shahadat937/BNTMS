using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDriving;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Handlers.Queries
{
    public class GetSwimmingDrivingDetailRequestHandler : IRequestHandler<GetSwimmingDrivingDetailRequest, SwimmingDrivingDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDriving> _SwimmingDrivingRepository;
        public GetSwimmingDrivingDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.SwimmingDriving> SwimmingDrivingRepository, IMapper mapper)
        {
            _SwimmingDrivingRepository = SwimmingDrivingRepository;
            _mapper = mapper;
        }
        public async Task<SwimmingDrivingDto> Handle(GetSwimmingDrivingDetailRequest request, CancellationToken cancellationToken)
        {
            var SwimmingDriving = await _SwimmingDrivingRepository.Get(request.SwimmingDrivingId);
            return _mapper.Map<SwimmingDrivingDto>(SwimmingDriving);
        }
    }
}
