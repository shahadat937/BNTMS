using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Heights.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Heights.Handler.Queries
{
    public class GetHeightsListRequestHandler : IRequestHandler<GetHeightsListRequest, PagedResult<HeightDto>>
    { 

        private readonly ISchoolManagementRepository<Height> _heightRepository;   

        private readonly IMapper _mapper;  

        public GetHeightsListRequestHandler(ISchoolManagementRepository<Height> heightRepository, IMapper mapper)
        {
            _heightRepository = heightRepository; 
            _mapper = mapper; 
        }

        public async Task<PagedResult<HeightDto>> Handle(GetHeightsListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<Height> heights = _heightRepository.FilterWithInclude(x =>x.HeightId != 26 && (x.HeightName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = heights.Count();
            heights = heights.OrderByDescending(x => x.HeightId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
             
            var heightsDtos = _mapper.Map<List<HeightDto>>(heights); 
            var result = new PagedResult<HeightDto>(heightsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
