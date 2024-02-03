using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.BnaServiceType;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Queries;
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

namespace SchoolManagement.Application.Features.BnaServiceTypes.Handlers.Queries
{
    public class GetBnaServiceTypeListRequestHandler : IRequestHandler<GetBnaServiceTypeListRequest, PagedResult<BnaServiceTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaServiceType> _BnaServiceTypeRepository;
         
        private readonly IMapper _mapper;

        public GetBnaServiceTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaServiceType> BnaServiceTypeRepository, IMapper mapper)
        {
            _BnaServiceTypeRepository = BnaServiceTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BnaServiceTypeDto>> Handle(GetBnaServiceTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BnaServiceType> BnaServiceTypes = _BnaServiceTypeRepository.FilterWithInclude(x => (x.ServiceName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BnaServiceTypes.Count();
            BnaServiceTypes = BnaServiceTypes.OrderByDescending(x => x.BnaServiceTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BnaServiceTypeDtos = _mapper.Map<List<BnaServiceTypeDto>>(BnaServiceTypes);
            var result = new PagedResult<BnaServiceTypeDto>(BnaServiceTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
