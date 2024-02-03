using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.DTOs.Weight;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.Weights.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Weights.Handlers.Queries 
{ 
    public class GetWeightsListRequestHandler : IRequestHandler<GetWeightsListRequest, PagedResult<WeightDto>>
    { 

        private readonly ISchoolManagementRepository<Weight> _weightRepository;    

        private readonly IMapper _mapper;  
         
        public GetWeightsListRequestHandler(ISchoolManagementRepository<Weight> weightRepository, IMapper mapper)
        {
            _weightRepository = weightRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<WeightDto>> Handle(GetWeightsListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<Weight> weights = _weightRepository.FilterWithInclude(x =>x.WeightId != 1059 && (x.WeightName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = weights.Count();
            weights = weights.OrderByDescending(x => x.WeightId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var weightsDtos = _mapper.Map<List<WeightDto>>(weights); 
            var result = new PagedResult<WeightDto>(weightsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
