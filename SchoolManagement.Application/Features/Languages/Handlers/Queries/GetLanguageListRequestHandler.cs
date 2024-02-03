using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Languages;
using SchoolManagement.Application.Features.Languages.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Languages.Handlers.Queries
{
    public class GetLanguageListRequestHandler : IRequestHandler<GetLanguageListRequest, PagedResult<LanguageDto>>
    { 

        private readonly ISchoolManagementRepository<Language> _LanguageRepository;    

        private readonly IMapper _mapper;  
         
        public GetLanguageListRequestHandler(ISchoolManagementRepository<Language> LanguageRepository, IMapper mapper)
        {
            _LanguageRepository = LanguageRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<LanguageDto>> Handle(GetLanguageListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<Language> Languages = _LanguageRepository.FilterWithInclude(x => (x.LanguageName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Languages.Count();
            Languages = Languages.OrderByDescending(x => x.LanguageId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var LanguagesDtos = _mapper.Map<List<LanguageDto>>(Languages); 
            var result = new PagedResult<LanguageDto>(LanguagesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
