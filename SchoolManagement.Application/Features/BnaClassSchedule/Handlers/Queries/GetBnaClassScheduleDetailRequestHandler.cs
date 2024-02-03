using AutoMapper;
using SchoolManagement.Application.DTOs.BnaClassSchedule;
using SchoolManagement.Application.Features.BnaClassSchedules.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Handlers.Queries
{
    public class GetBnaClassScheduleDetailRequestHandler : IRequestHandler<GetBnaClassScheduleDetailRequest, BnaClassScheduleDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaClassSchedule> _BnaClassScheduleRepository;
        public GetBnaClassScheduleDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaClassSchedule> BnaClassScheduleRepository, IMapper mapper)
        {
            _BnaClassScheduleRepository = BnaClassScheduleRepository;
            _mapper = mapper;
        }
        public async Task<BnaClassScheduleDto> Handle(GetBnaClassScheduleDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaClassSchedule = await _BnaClassScheduleRepository.FindOneAsync(x => x.BnaClassScheduleId == request.BnaClassScheduleId);
            return _mapper.Map<BnaClassScheduleDto>(BnaClassSchedule);
        }
    }
}
