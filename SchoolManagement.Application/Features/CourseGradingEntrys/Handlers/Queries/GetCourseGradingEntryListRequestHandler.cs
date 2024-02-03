using SchoolManagement.Application.Features.CourseGradingEntrys.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseGradingEntry;
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


namespace SchoolManagement.Application.Features.CourseGradingEntrys.Handlers.Queries
{
    public class GetCourseGradingEntryListRequestHandler : IRequestHandler<GetCourseGradingEntryListRequest, PagedResult<CourseGradingEntryDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CourseGradingEntry> _CourseGradingEntryRepository;

        private readonly IMapper _mapper;

        public GetCourseGradingEntryListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CourseGradingEntry> CourseGradingEntryRepository, IMapper mapper)
        {
            _CourseGradingEntryRepository = CourseGradingEntryRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CourseGradingEntryDto>> Handle(GetCourseGradingEntryListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CourseGradingEntry> CourseGradingEntrys = _CourseGradingEntryRepository.FilterWithInclude(x => (x.Grade.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CourseGradingEntrys.Count();
            CourseGradingEntrys = CourseGradingEntrys.OrderByDescending(x => x.CourseGradingEntryId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CourseGradingEntryDtos = _mapper.Map<List<CourseGradingEntryDto>>(CourseGradingEntrys);
            var result = new PagedResult<CourseGradingEntryDto>(CourseGradingEntryDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
