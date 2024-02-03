using AutoMapper;
using SchoolManagement.Application.DTOs.CourseModule;
using SchoolManagement.Application.Features.CourseModules.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseModules.Handlers.Queries
{
    public class GetCourseModuleListRequestHandler : IRequestHandler<GetCourseModuleListRequest, PagedResult<CourseModuleDto>>
    {

        private readonly ISchoolManagementRepository<CourseModule> _CourseModuleRepository;

        private readonly IMapper _mapper;

        public GetCourseModuleListRequestHandler(ISchoolManagementRepository<CourseModule> CourseModuleRepository, IMapper mapper)
        {
            _CourseModuleRepository = CourseModuleRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseModuleDto>> Handle(GetCourseModuleListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CourseModule> CourseModules = _CourseModuleRepository.FilterWithInclude(x => (x.ModuleName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseName", "BaseSchoolName");
            var totalCount = CourseModules.Count();
            CourseModules = CourseModules.OrderByDescending(x => x.CourseModuleId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseModuleDtos = _mapper.Map<List<CourseModuleDto>>(CourseModules);
            var result = new PagedResult<CourseModuleDto>(CourseModuleDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
