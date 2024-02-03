using SchoolManagement.Application.Contracts.Persistence;
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
using SchoolManagement.Application.DTOs.CourseInstructors;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseInstructors.Requests.Queries;

namespace SchoolManagement.Application.Features.CourseInstructors.Handlers.Queries
{
    public class GetCourseInstructorListRequestHandler : IRequestHandler<GetCourseInstructorListRequest, PagedResult<CourseInstructorDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseInstructor> _CourseInstructorRepository;

        private readonly IMapper _mapper;

        public GetCourseInstructorListRequestHandler(ISchoolManagementRepository<CourseInstructor> CourseInstructorRepository, IMapper mapper)
        {
            _CourseInstructorRepository = CourseInstructorRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseInstructorDto>> Handle(GetCourseInstructorListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false) 
                throw new ValidationException(validationResult);

            IQueryable<CourseInstructor> CourseInstructors = _CourseInstructorRepository.FilterWithInclude(x =>String.IsNullOrEmpty(request.QueryParams.SearchText), "CourseDuration", "BaseSchoolName", "CourseName", "BnaSubjectName", "MarkType", "CourseModule", "Trainee.Rank");
            var totalCount = CourseInstructors.Count();
            CourseInstructors = CourseInstructors.OrderByDescending(x => x.CourseInstructorId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);  

            var CourseInstructorDtos = _mapper.Map<List<CourseInstructorDto>>(CourseInstructors);
            var result = new PagedResult<CourseInstructorDto>(CourseInstructorDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);
            return result;
        }
    }
}