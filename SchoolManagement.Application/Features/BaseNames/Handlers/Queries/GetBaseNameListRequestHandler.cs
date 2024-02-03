using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.BaseNames;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BaseNames.Requests.Queries;

namespace SchoolManagement.Application.Features.BaseNames.Handlers.Queries 
{ 
    public class GetBaseNameListRequestHandler : IRequestHandler<GetBaseNameListRequest, PagedResult<BaseNameDto>>
    { 

        private readonly ISchoolManagementRepository<BaseName> _BaseNameRepository;    

        private readonly IMapper _mapper;  
         
        public GetBaseNameListRequestHandler(ISchoolManagementRepository<BaseName> BaseNameRepository, IMapper mapper)
        {
            _BaseNameRepository = BaseNameRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<BaseNameDto>> Handle(GetBaseNameListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<BaseName> BaseNames = _BaseNameRepository.FilterWithInclude(x => (x.BaseNames.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)), "AdminAuthority", "Division", "District");
            var totalCount = BaseNames.Count();
            BaseNames = BaseNames.OrderByDescending(x => x.BaseNameId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var BaseNamesDtos = _mapper.Map<List<BaseNameDto>>(BaseNames); 
            var result = new PagedResult<BaseNameDto>(BaseNamesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
