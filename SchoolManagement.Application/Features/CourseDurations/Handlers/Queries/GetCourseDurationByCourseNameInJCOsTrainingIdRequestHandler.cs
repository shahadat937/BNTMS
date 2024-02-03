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
    public class GetCourseDurationByCourseNameInJCOsTrainingIdRequestHandler : IRequestHandler<GetCourseDurationByCourseNameInJCOsTrainingIdRequest, PagedResult<CourseDurationDto>>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;

        private readonly IMapper _mapper;
        public GetCourseDurationByCourseNameInJCOsTrainingIdRequestHandler(ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IMapper mapper)
        {
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseDurationDto>> Handle(GetCourseDurationByCourseNameInJCOsTrainingIdRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            IQueryable<CourseDuration> CourseDurations = _CourseDurationRepository.FilterWithInclude(x => (x.CourseTitle.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "BaseSchoolName", "Country", "CourseName", "CourseType", "FiscalYear", "OrganizationName").Where(x => x.CourseNameId == 1253);
            var totalCount = CourseDurations.Count();

            CourseDurations = CourseDurations.Where(x => x.CourseNameId == 1253).OrderByDescending(x => x.CourseDurationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);


            var CourseDurationDtos = _mapper.Map<List<CourseDurationDto>>(CourseDurations);
            var result = new PagedResult<CourseDurationDto>(CourseDurationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
        
    }
}
