using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.UtofficerType;
using SchoolManagement.Application.Features.UtofficerTypes.Requests;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Queries;
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

namespace SchoolManagement.Application.Features.UtofficerTypes.Handlers.Queries
{
    public class GetUtofficerTypeListRequestHandler : IRequestHandler<GetUtofficerTypeListRequest, PagedResult<UtofficerTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.UtofficerType> _UtofficerTypeRepository;

        private readonly IMapper _mapper;

        public GetUtofficerTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.UtofficerType> UtofficerTypeRepository, IMapper mapper)
        {
            _UtofficerTypeRepository = UtofficerTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<UtofficerTypeDto>> Handle(GetUtofficerTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.UtofficerType> UtofficerTypes = _UtofficerTypeRepository.FilterWithInclude(x => (x.UtofficerTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = UtofficerTypes.Count();
            UtofficerTypes = UtofficerTypes.OrderByDescending(x => x.UtofficerTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var UtofficerTypeDtos = _mapper.Map<List<UtofficerTypeDto>>(UtofficerTypes);
            var result = new PagedResult<UtofficerTypeDto>(UtofficerTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
