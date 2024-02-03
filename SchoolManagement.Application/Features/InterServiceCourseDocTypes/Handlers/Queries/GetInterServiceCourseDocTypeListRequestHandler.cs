using SchoolManagement.Application.Features.InterServiceCourseDocTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.InterServiceCourseDocType;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.InterServiceCourseDocTypes.Handlers.Queries
{
    public class GetInterServiceCourseDocTypeListRequestHandler : IRequestHandler<GetInterServiceCourseDocTypeListRequest, PagedResult<InterServiceCourseDocTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseDocType> _InterServiceCourseDocTypeRepository;

        private readonly IMapper _mapper;

        public GetInterServiceCourseDocTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.InterServiceCourseDocType> InterServiceCourseDocTypeRepository, IMapper mapper)
        {
            _InterServiceCourseDocTypeRepository = InterServiceCourseDocTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<InterServiceCourseDocTypeDto>> Handle(GetInterServiceCourseDocTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.InterServiceCourseDocType> InterServiceCourseDocTypes = _InterServiceCourseDocTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = InterServiceCourseDocTypes.Count();
            InterServiceCourseDocTypes = InterServiceCourseDocTypes.OrderByDescending(x => x.InterServiceCourseDocTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var InterServiceCourseDocTypeDtos = _mapper.Map<List<InterServiceCourseDocTypeDto>>(InterServiceCourseDocTypes);
            var result = new PagedResult<InterServiceCourseDocTypeDto>(InterServiceCourseDocTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
