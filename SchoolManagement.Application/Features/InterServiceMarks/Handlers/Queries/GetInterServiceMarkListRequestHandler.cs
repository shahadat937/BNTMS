using SchoolManagement.Application.Features.InterServiceMarks.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceMark;
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
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Queries
{
    public class GetInterServiceMarkListRequestHandler : IRequestHandler<GetInterServiceMarkListRequest, PagedResult<InterServiceMarkDto>>
    {

        private readonly ISchoolManagementRepository<InterServiceMark> _InterServiceMarkRepository;

        private readonly IMapper _mapper;

        public GetInterServiceMarkListRequestHandler(ISchoolManagementRepository<InterServiceMark> InterServiceMarkRepository, IMapper mapper)
        {
            _InterServiceMarkRepository = InterServiceMarkRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<InterServiceMarkDto>> Handle(GetInterServiceMarkListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<InterServiceMark> InterServiceMarks = _InterServiceMarkRepository.FilterWithInclude(x => (x.CoursePosition.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)),  "Document", "CourseDuration.CourseName", "OrganizationName");
            var totalCount = InterServiceMarks.Count();
            InterServiceMarks = InterServiceMarks.OrderByDescending(x => x.InterServiceMarkId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var InterServiceMarkDtos = _mapper.Map<List<InterServiceMarkDto>>(InterServiceMarks);
            var result = new PagedResult<InterServiceMarkDto>(InterServiceMarkDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
