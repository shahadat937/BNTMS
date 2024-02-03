using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.MilitaryTrainings.Requests.Queries;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Handlers.Queries 
{ 
    public class GetMilitaryTrainingListRequestHandler : IRequestHandler<GetMilitaryTrainingListRequest, PagedResult<MilitaryTrainingDto>>
    { 

        private readonly ISchoolManagementRepository<MilitaryTraining> _MilitaryTrainingRepository;    

        private readonly IMapper _mapper;  
         
        public GetMilitaryTrainingListRequestHandler(ISchoolManagementRepository<MilitaryTraining> MilitaryTrainingRepository, IMapper mapper)
        {
            _MilitaryTrainingRepository = MilitaryTrainingRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<MilitaryTrainingDto>> Handle(GetMilitaryTrainingListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<MilitaryTraining> MilitaryTrainings = _MilitaryTrainingRepository.FilterWithInclude(x => String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = MilitaryTrainings.Count();
            MilitaryTrainings = MilitaryTrainings.OrderByDescending(x => x.MilitaryTrainingId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var MilitaryTrainingsDtos = _mapper.Map<List<MilitaryTrainingDto>>(MilitaryTrainings); 
            var result = new PagedResult<MilitaryTrainingDto>(MilitaryTrainingsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
