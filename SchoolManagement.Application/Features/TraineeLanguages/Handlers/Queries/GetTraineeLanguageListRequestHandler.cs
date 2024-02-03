using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.TraineeLanguages;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.TraineeLanguages.Requests.Queries;

namespace SchoolManagement.Application.Features.TraineeLanguages.Handlers.Queries 
{ 
    public class GetTraineeLanguageListRequestHandler : IRequestHandler<GetTraineeLanguageListRequest, PagedResult<TraineeLanguageDto>>
    { 

        private readonly ISchoolManagementRepository<TraineeLanguage> _TraineeLanguageRepository;    

        private readonly IMapper _mapper;  
         
        public GetTraineeLanguageListRequestHandler(ISchoolManagementRepository<TraineeLanguage> TraineeLanguageRepository, IMapper mapper)
        {
            _TraineeLanguageRepository = TraineeLanguageRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<TraineeLanguageDto>> Handle(GetTraineeLanguageListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<TraineeLanguage> TraineeLanguages = _TraineeLanguageRepository.FilterWithInclude(x => (x.AdditionalInformation.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)),"Language");
            var totalCount = TraineeLanguages.Count();
            TraineeLanguages = TraineeLanguages.OrderByDescending(x => x.TraineeLanguageId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var TraineeLanguagesDtos = _mapper.Map<List<TraineeLanguageDto>>(TraineeLanguages); 
            var result = new PagedResult<TraineeLanguageDto>(TraineeLanguagesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
