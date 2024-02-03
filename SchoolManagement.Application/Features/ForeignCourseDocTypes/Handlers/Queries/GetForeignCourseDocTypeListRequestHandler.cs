using SchoolManagement.Application.Features.ForeignCourseDocTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ForeignCourseDocType;
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


namespace SchoolManagement.Application.Features.ForeignCourseDocTypes.Handlers.Queries
{
    public class GetForeignCourseDocTypeListRequestHandler : IRequestHandler<GetForeignCourseDocTypeListRequest, PagedResult<ForeignCourseDocTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseDocType> _ForeignCourseDocTypeRepository;

        private readonly IMapper _mapper;

        public GetForeignCourseDocTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ForeignCourseDocType> ForeignCourseDocTypeRepository, IMapper mapper)
        {
            _ForeignCourseDocTypeRepository = ForeignCourseDocTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ForeignCourseDocTypeDto>> Handle(GetForeignCourseDocTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ForeignCourseDocType> ForeignCourseDocTypes = _ForeignCourseDocTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ForeignCourseDocTypes.Count();
            ForeignCourseDocTypes = ForeignCourseDocTypes.OrderByDescending(x => x.ForeignCourseDocTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ForeignCourseDocTypeDtos = _mapper.Map<List<ForeignCourseDocTypeDto>>(ForeignCourseDocTypes);
            var result = new PagedResult<ForeignCourseDocTypeDto>(ForeignCourseDocTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
