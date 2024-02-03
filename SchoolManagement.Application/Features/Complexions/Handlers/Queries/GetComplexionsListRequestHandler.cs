using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Complexions.Handler.Queries 
{
    public class GetComplexionsListRequestHandler : IRequestHandler<GetComplexionsListRequest, PagedResult<ComplexionDto>>
    { 

        private readonly ISchoolManagementRepository<Complexion> _complexionRepository;  

        private readonly IMapper _mapper; 

        public GetComplexionsListRequestHandler(ISchoolManagementRepository<Complexion> complexionRepository, IMapper mapper)
        {
            _complexionRepository = complexionRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<ComplexionDto>> Handle(GetComplexionsListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString());

            IQueryable<Complexion> complexions = _complexionRepository.FilterWithInclude(x => (x.ComplexionName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = complexions.Count();
            complexions = complexions.OrderByDescending(x => x.ComplexionId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var complexionsDtos = _mapper.Map<List<ComplexionDto>>(complexions); 
            var result = new PagedResult<ComplexionDto>(complexionsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
