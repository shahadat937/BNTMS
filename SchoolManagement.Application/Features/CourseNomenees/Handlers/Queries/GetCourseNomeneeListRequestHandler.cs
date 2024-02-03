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
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Queries;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Queries
{
    public class GetCourseNomeneeListRequestHandler : IRequestHandler<GetCourseNomeneeListRequest, PagedResult<CourseNomeneeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseNomenee> _CourseNomeneeRepository;

        private readonly IMapper _mapper;

        public GetCourseNomeneeListRequestHandler(ISchoolManagementRepository<CourseNomenee> CourseNomeneeRepository, IMapper mapper)
        {
            _CourseNomeneeRepository = CourseNomeneeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseNomeneeDto>> Handle(GetCourseNomeneeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false) 
                throw new ValidationException(validationResult);

            IQueryable<CourseNomenee> CourseNomenees = _CourseNomeneeRepository.FilterWithInclude(x =>String.IsNullOrEmpty(request.QueryParams.SearchText), "CourseDuration", "BaseSchoolName", "CourseName", "BnaSubjectName", "MarkType", "CourseModule", "Trainee.Rank");
            var totalCount = CourseNomenees.Count();
            CourseNomenees = CourseNomenees.OrderByDescending(x => x.CourseNomeneeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);  

            var CourseNomeneeDtos = _mapper.Map<List<CourseNomeneeDto>>(CourseNomenees);
            var result = new PagedResult<CourseNomeneeDto>(CourseNomeneeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);
            return result;
        }
    }
}