using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CourseTerm;
using SchoolManagement.Application.Features.CourseTerms.Requests;
using SchoolManagement.Application.Features.CourseTerms.Requests.Queries;
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

namespace SchoolManagement.Application.Features.CourseTerms.Handlers.Queries
{
    public class GetCourseTermListRequestHandler : IRequestHandler<GetCourseTermListRequest, PagedResult<CourseTermDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseTerm> _CourseTermRepository;

        private readonly IMapper _mapper;

        public GetCourseTermListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseTerm> CourseTermRepository, IMapper mapper)
        {
            _CourseTermRepository = CourseTermRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseTermDto>> Handle(GetCourseTermListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CourseTerm> CourseTerms = _CourseTermRepository.FilterWithInclude(x => (x.CourseTermTitle.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CourseTerms.Count();
            CourseTerms = CourseTerms.OrderByDescending(x => x.CourseTermId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseTermDtos = _mapper.Map<List<CourseTermDto>>(CourseTerms);
            var result = new PagedResult<CourseTermDto>(CourseTermDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
