using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationListByBaseSchoolNameIdRequestHandler : IRequestHandler<GetCourseDurationListByBaseSchoolNameIdRequest, List<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;
        private readonly IMapper _mapper;

        public GetCourseDurationListByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDurationDto>> Handle(GetCourseDurationListByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> CourseDurations =  _CourseDurationRepository.FilterWithInclude(x =>x.BaseSchoolNameId == request.BaseSchoolNameId && x.IsCompletedStatus == 0, "CourseName", "BaseSchoolName");

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);
            return CourseDurationDtos;
        }
    }
}
