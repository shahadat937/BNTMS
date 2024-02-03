using AutoMapper;
using SchoolManagement.Application.DTOs.ParentRelative;
using SchoolManagement.Application.Features.ParentRelatives.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.ParentRelatives.Handlers.Queries
{
    public class GetParentRelativeListRequestHandler : IRequestHandler<GetParentRelativeListRequest, PagedResult<ParentRelativeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ParentRelative> _ParentRelativeRepository;

        private readonly IMapper _mapper;

        public GetParentRelativeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ParentRelative> ParentRelativeRepository, IMapper mapper)
        {
            _ParentRelativeRepository = ParentRelativeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ParentRelativeDto>> Handle(GetParentRelativeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ParentRelative> ParentRelatives = _ParentRelativeRepository.FilterWithInclude(x => (x.NameInFull.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ParentRelatives.Count();
            ParentRelatives = ParentRelatives.OrderByDescending(x => x.ParentRelativeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ParentRelativeDtos = _mapper.Map<List<ParentRelativeDto>>(ParentRelatives);
            var result = new PagedResult<ParentRelativeDto>(ParentRelativeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
