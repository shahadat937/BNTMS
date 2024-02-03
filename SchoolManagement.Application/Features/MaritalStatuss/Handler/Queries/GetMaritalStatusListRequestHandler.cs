using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MaritalStatus;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.MaritalStatuss.Requests.Queries;

namespace SchoolManagement.Application.Features.MaritalStatuss.Handler.Queries
{
    public class GetMaritalStatusListRequestHandler : IRequestHandler<GetMaritalStatusListRequest, PagedResult<MaritalStatusDto>>
    { 

        private readonly ISchoolManagementRepository<MaritalStatus> _maritalStatusRepository;  

        private readonly IMapper _mapper;

        public GetMaritalStatusListRequestHandler(ISchoolManagementRepository<MaritalStatus> maritalStatusRepository, IMapper mapper)
        {
            _maritalStatusRepository = maritalStatusRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<MaritalStatusDto>> Handle(GetMaritalStatusListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false) 
                throw new ValidationException(validationResult.ToString());

            IQueryable<MaritalStatus> maritalStatus = _maritalStatusRepository.FilterWithInclude(x =>x.MaritalStatusId != 14 && (x.MaritalStatusName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = maritalStatus.Count();
            maritalStatus = maritalStatus.OrderByDescending(x => x.MaritalStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var maritalStatusDtos = _mapper.Map<List<MaritalStatusDto>>(maritalStatus);
            var result = new PagedResult<MaritalStatusDto>(maritalStatusDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
