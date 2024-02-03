using SchoolManagement.Application.Features.ReasonTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ReasonType;
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


namespace SchoolManagement.Application.Features.ReasonTypes.Handlers.Queries
{
    public class GetReasonTypeListRequestHandler : IRequestHandler<GetReasonTypeListRequest, PagedResult<ReasonTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ReasonType> _ReasonTypeRepository;

        private readonly IMapper _mapper;

        public GetReasonTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ReasonType> ReasonTypeRepository, IMapper mapper)
        {
            _ReasonTypeRepository = ReasonTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ReasonTypeDto>> Handle(GetReasonTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.ReasonType> ReasonTypes = _ReasonTypeRepository.FilterWithInclude(x => (x.ReasonTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = ReasonTypes.Count();
            ReasonTypes = ReasonTypes.OrderByDescending(x => x.ReasonTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var ReasonTypeDtos = _mapper.Map<List<ReasonTypeDto>>(ReasonTypes);
            var result = new PagedResult<ReasonTypeDto>(ReasonTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
