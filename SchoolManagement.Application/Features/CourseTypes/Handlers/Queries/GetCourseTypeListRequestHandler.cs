using SchoolManagement.Application.Features.CourseTypes.Requests.Queries;
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
using SchoolManagement.Application.DTOs.CourseTypes;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseTypes.Handlers.Queries
{
    public class GetCourseTypeListRequestHandler : IRequestHandler<GetCourseTypeListRequest, PagedResult<CourseTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseType> _CourseTypeRepository;

        private readonly IMapper _mapper;

        public GetCourseTypeListRequestHandler(ISchoolManagementRepository<CourseType> CourseTypeRepository, IMapper mapper)
        {
            _CourseTypeRepository = CourseTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseTypeDto>> Handle(GetCourseTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<CourseType> CourseTypes = _CourseTypeRepository.FilterWithInclude(x => (x.CourseTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CourseTypes.Count();
            CourseTypes = CourseTypes.OrderByDescending(x => x.CourseTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseTypeDtos = _mapper.Map<List<CourseTypeDto>>(CourseTypes);
            var result = new PagedResult<CourseTypeDto>(CourseTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
