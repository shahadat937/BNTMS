using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CoursePlan;
using SchoolManagement.Application.Features.CoursePlans.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CoursePlans.Handlers.Queries
{
    public class GetCoursePlanDetailRequestHandler : IRequestHandler<GetCoursePlanDetailRequest, CoursePlanDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<CoursePlanCreate> _CoursePlanRepository;
        public GetCoursePlanDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CoursePlanCreate> CoursePlanRepository, IMapper mapper)
        {
            _CoursePlanRepository = CoursePlanRepository;
            _mapper = mapper;
        }
        public async Task<CoursePlanDto> Handle(GetCoursePlanDetailRequest request, CancellationToken cancellationToken)
        {
            var CoursePlan = await _CoursePlanRepository.Get(request.CoursePlanCreateId);
            return _mapper.Map<CoursePlanDto>(CoursePlan);
        }
    }
}
