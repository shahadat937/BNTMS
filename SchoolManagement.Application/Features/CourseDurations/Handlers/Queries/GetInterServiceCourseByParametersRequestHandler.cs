using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.CourseDurations;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetInterServiceCourseByParametersRequestHandler : IRequestHandler<GetInterServiceCourseByParametersRequest, List<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;
        public GetInterServiceCourseByParametersRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseDurationDto>> Handle(GetInterServiceCourseByParametersRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => x.CourseNameId == request.CourseNameId && x.OrganizationNameId == request.OrganizationNameId && x.IsCompletedStatus == 0,  "CourseName", "OrganizationName");

            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);

            return CourseDurationDtos;
        }
        
    }
}
