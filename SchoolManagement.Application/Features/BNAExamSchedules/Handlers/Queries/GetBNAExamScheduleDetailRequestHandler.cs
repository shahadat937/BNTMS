using AutoMapper;
using SchoolManagement.Application.DTOs.BnaExamSchedule;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Handlers.Queries
{
    public class GetBnaExamScheduleDetailRequestHandler : IRequestHandler<GetBnaExamScheduleDetailRequest, BnaExamScheduleDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<BnaExamSchedule> _BnaExamScheduleRepository;
        public GetBnaExamScheduleDetailRequestHandler(ISchoolManagementRepository<BnaExamSchedule> BnaExamScheduleRepository, IMapper mapper)
        {
            _BnaExamScheduleRepository = BnaExamScheduleRepository;
            _mapper = mapper;
        }
        public async Task<BnaExamScheduleDto> Handle(GetBnaExamScheduleDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaExamSchedule = await _BnaExamScheduleRepository.Get(request.BnaExamScheduleId);
            return _mapper.Map<BnaExamScheduleDto>(BnaExamSchedule);
        }
    }
}
