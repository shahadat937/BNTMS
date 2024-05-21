using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseLevel;
using SchoolManagement.Application.Features.CourseLevels.Requests;
using SchoolManagement.Application.Features.CourseLevels.Requests.Queries;
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

namespace SchoolManagement.Application.Features.CourseLevels.Handlers.Queries
{
    public class GetCourseLevelListRequestHandler : IRequestHandler<GetCourseLevelListRequest, PagedResult<CourseLevelDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseLevel> _CourseLevelRepository;

        private readonly IMapper _mapper;

        public GetCourseLevelListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseLevel> CourseLevelRepository, IMapper mapper)
        {
            _CourseLevelRepository = CourseLevelRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseLevelDto>> Handle(GetCourseLevelListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CourseLevel> CourseLevels = _CourseLevelRepository.FilterWithInclude(x => (x.CourseLeveTitle.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CourseLevels.Count();
            CourseLevels = CourseLevels.OrderByDescending(x => x.CourseLevelId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseLevelDtos = _mapper.Map<List<CourseLevelDto>>(CourseLevels);
            var result = new PagedResult<CourseLevelDto>(CourseLevelDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
