using SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseOtherDoc;
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


namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Handlers.Queries
{
    public class GetForeignCourseOtherDocListRequestHandler : IRequestHandler<GetForeignCourseOtherDocListRequest, PagedResult<ForeignCourseOtherDocDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOtherDoc> _ForeignCourseOtherDocRepository;

        private readonly IMapper _mapper;

        public GetForeignCourseOtherDocListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseOtherDoc> ForeignCourseOtherDocRepository, IMapper mapper)
        {
            _ForeignCourseOtherDocRepository = ForeignCourseOtherDocRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ForeignCourseOtherDocDto>> Handle(GetForeignCourseOtherDocListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ForeignCourseOtherDoc> UTOfficerCategories = _ForeignCourseOtherDocRepository.FilterWithInclude(x => (x.CourseName.Course.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseDuration.CourseName");
            var totalCount = UTOfficerCategories.Count();
            UTOfficerCategories = UTOfficerCategories.OrderByDescending(x => x.ForeignCourseOtherDocId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ForeignCourseOtherDocDtos = _mapper.Map<List<ForeignCourseOtherDocDto>>(UTOfficerCategories);
            var result = new PagedResult<ForeignCourseOtherDocDto>(ForeignCourseOtherDocDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
