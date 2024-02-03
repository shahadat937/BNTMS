using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.CoCurricularActivityType;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Queries;
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

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Handlers.Queries
{
    public class GetCoCurricularActivityTypeListRequestHandler : IRequestHandler<GetCoCurricularActivityTypeListRequest, PagedResult<CoCurricularActivityTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivityType> _CoCurricularActivityTypeRepository;

        private readonly IMapper _mapper;

        public GetCoCurricularActivityTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.CoCurricularActivityType> CoCurricularActivityTypeRepository, IMapper mapper)
        {
            _CoCurricularActivityTypeRepository = CoCurricularActivityTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<CoCurricularActivityTypeDto>> Handle(GetCoCurricularActivityTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.CoCurricularActivityType> CoCurricularActivityTypes = _CoCurricularActivityTypeRepository.FilterWithInclude(x => (x.CoCurricularActivityName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = CoCurricularActivityTypes.Count();
            CoCurricularActivityTypes = CoCurricularActivityTypes.OrderByDescending(x => x.CoCurricularActivityTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var CoCurricularActivityTypeDtos = _mapper.Map<List<CoCurricularActivityTypeDto>>(CoCurricularActivityTypes);
            var result = new PagedResult<CoCurricularActivityTypeDto>(CoCurricularActivityTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
