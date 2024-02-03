using SchoolManagement.Application.Features.BudgetTypes.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetType;
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


namespace SchoolManagement.Application.Features.BudgetTypes.Handlers.Queries
{
    public class GetBudgetCodeListRequestHandler : IRequestHandler<GetBudgetTypeListRequest, PagedResult<BudgetTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BudgetType> _BudgetTypeRepository;

        private readonly IMapper _mapper;

        public GetBudgetCodeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BudgetType> BudgetTypeRepository, IMapper mapper)
        {
            _BudgetTypeRepository = BudgetTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<BudgetTypeDto>> Handle(GetBudgetTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.BudgetType> BudgetTypes = _BudgetTypeRepository.FilterWithInclude(x => (x.BudgetTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = BudgetTypes.Count();
            BudgetTypes = BudgetTypes.OrderByDescending(x => x.BudgetTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var BudgetTypeDtos = _mapper.Map<List<BudgetTypeDto>>(BudgetTypes);
            var result = new PagedResult<BudgetTypeDto>(BudgetTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
