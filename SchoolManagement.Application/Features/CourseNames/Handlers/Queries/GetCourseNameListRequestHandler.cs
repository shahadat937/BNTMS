using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseName;
using SchoolManagement.Application.Features.CourseNames.Requests;
using SchoolManagement.Application.Features.CourseNames.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.CourseNames.Handlers.Queries
{
    public class GetCourseNameListRequestHandler : IRequestHandler<GetCourseNameListRequest, PagedResult<CourseNameDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseName> _CourseNameRepository;

        private readonly IMapper _mapper;

        public GetCourseNameListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseName> CourseNameRepository, IMapper mapper)
        {
            _CourseNameRepository = CourseNameRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseNameDto>> Handle(GetCourseNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CourseName> CourseNames = _CourseNameRepository.FilterWithInclude(x => (x.Course.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseType");
            var totalCount = CourseNames.Count();
            CourseNames = CourseNames.OrderByDescending(x => x.CourseNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseNameDtos = _mapper.Map<List<CourseNameDto>>(CourseNames);
            var result = new PagedResult<CourseNameDto>(CourseNameDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
