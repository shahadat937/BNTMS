using SchoolManagement.Application.Features.WithdrawnTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.WithdrawnType;
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

namespace SchoolManagement.Application.Features.WithdrawnTypes.Handlers.Queries
{
    public class GetWithdrawnTypeListRequestHandler : IRequestHandler<GetWithdrawnTypeListRequest, PagedResult<WithdrawnTypeDto>>
    {

        private readonly ISchoolManagementRepository<WithdrawnType> _WithdrawnTypeRepository;

        private readonly IMapper _mapper;

        public GetWithdrawnTypeListRequestHandler(ISchoolManagementRepository<WithdrawnType> WithdrawnTypeRepository, IMapper mapper)
        {
            _WithdrawnTypeRepository = WithdrawnTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<WithdrawnTypeDto>> Handle(GetWithdrawnTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<WithdrawnType> WithdrawnTypes = _WithdrawnTypeRepository.FilterWithInclude(x => (x.Name.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = WithdrawnTypes.Count();
            WithdrawnTypes = WithdrawnTypes.OrderBy(x => x.MenuPosition).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var WithdrawnTypeDtos = _mapper.Map<List<WithdrawnTypeDto>>(WithdrawnTypes);
            var result = new PagedResult<WithdrawnTypeDto>(WithdrawnTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
