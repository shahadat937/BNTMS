using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.RecordOfService;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Queries;

namespace SchoolManagement.Application.Features.RecordOfServices.Handlers.Queries 
{ 
    public class GetRecordOfServiceListRequestHandler : IRequestHandler<GetRecordOfServiceListRequest, PagedResult<RecordOfServiceDto>>
    { 

        private readonly ISchoolManagementRepository<RecordOfService> _RecordOfServiceRepository;    

        private readonly IMapper _mapper;  
         
        public GetRecordOfServiceListRequestHandler(ISchoolManagementRepository<RecordOfService> RecordOfServiceRepository, IMapper mapper)
        {
            _RecordOfServiceRepository = RecordOfServiceRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<RecordOfServiceDto>> Handle(GetRecordOfServiceListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<RecordOfService> RecordOfServices = _RecordOfServiceRepository.FilterWithInclude(x => (x.ShipEstablishment.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = RecordOfServices.Count();
            RecordOfServices = RecordOfServices.OrderByDescending(x => x.RecordOfServiceId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var RecordOfServicesDtos = _mapper.Map<List<RecordOfServiceDto>>(RecordOfServices); 
            var result = new PagedResult<RecordOfServiceDto>(RecordOfServicesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
