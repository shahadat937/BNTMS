using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Electeds;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.Electeds.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Electeds.Handlers.Queries 
{ 
    public class GetElectedListRequestHandler : IRequestHandler<GetElectedListRequest, PagedResult<ElectedDto>>
    { 

        private readonly ISchoolManagementRepository<Elected> _ElectedRepository;    

        private readonly IMapper _mapper;  
         
        public GetElectedListRequestHandler(ISchoolManagementRepository<Elected> ElectedRepository, IMapper mapper)
        {
            _ElectedRepository = ElectedRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<ElectedDto>> Handle(GetElectedListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<Elected> Electeds = _ElectedRepository.FilterWithInclude(x => (x.ElectedType.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Electeds.Count();
            Electeds = Electeds.OrderByDescending(x => x.ElectedId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var ElectedsDtos = _mapper.Map<List<ElectedDto>>(Electeds); 
            var result = new PagedResult<ElectedDto>(ElectedsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
