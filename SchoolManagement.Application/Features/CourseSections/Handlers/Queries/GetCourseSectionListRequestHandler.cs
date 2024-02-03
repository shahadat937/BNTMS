using AutoMapper;
using SchoolManagement.Application.DTOs.CourseSection;
using SchoolManagement.Application.Features.CourseSections.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseSections.Handlers.Queries
{
    public class GetCourseSectionListRequestHandler : IRequestHandler<GetCourseSectionListRequest, PagedResult<CourseSectionDto>>
    {

        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;

        private readonly IMapper _mapper;

        public GetCourseSectionListRequestHandler(ISchoolManagementRepository<CourseSection> CourseSectionRepository, IMapper mapper)
        {
            _CourseSectionRepository = CourseSectionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseSectionDto>> Handle(GetCourseSectionListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CourseSection> CourseSections = _CourseSectionRepository.FilterWithInclude(x => (x.SectionName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "BaseSchoolName");
            var totalCount = CourseSections.Count();
            CourseSections = CourseSections.OrderByDescending(x => x.CourseSectionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseSectionDtos = _mapper.Map<List<CourseSectionDto>>(CourseSections);
            var result = new PagedResult<CourseSectionDto>(CourseSectionDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
