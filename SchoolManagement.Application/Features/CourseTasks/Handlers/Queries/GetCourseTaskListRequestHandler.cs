using SchoolManagement.Application.Features.CourseTasks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseTask;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.CourseTasks.Handlers.Queries
{
    public class GetCourseTaskListRequestHandler : IRequestHandler<GetCourseTaskListRequest, PagedResult<CourseTaskDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseTask> _CourseTaskRepository;

        private readonly IMapper _mapper;

        public GetCourseTaskListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseTask> CourseTaskRepository, IMapper mapper)
        {
            _CourseTaskRepository = CourseTaskRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseTaskDto>> Handle(GetCourseTaskListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CourseTask> CourseTasks = _CourseTaskRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "BaseSchoolName", "CourseName", "BnaSubjectName");
            var totalCount = CourseTasks.Count();
            CourseTasks = CourseTasks.OrderByDescending(x => x.CourseTaskId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseTaskDtos = _mapper.Map<List<CourseTaskDto>>(CourseTasks);
            var result = new PagedResult<CourseTaskDto>(CourseTaskDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
