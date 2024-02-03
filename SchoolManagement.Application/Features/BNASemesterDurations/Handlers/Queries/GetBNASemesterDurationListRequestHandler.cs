using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.BnaSemesterDurations;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaSemesterDurations.Requests.Queries;

namespace SchoolManagement.Application.Features.BnaSemesterDurations.Handlers.Queries 
{ 
    public class GetBnaSemesterDurationListRequestHandler : IRequestHandler<GetBnaSemesterDurationListRequest, PagedResult<BnaSemesterDurationDto>>
    { 

        private readonly ISchoolManagementRepository<BnaSemesterDuration> _BnaSemesterDurationRepository;    

        private readonly IMapper _mapper;  
         
        public GetBnaSemesterDurationListRequestHandler(ISchoolManagementRepository<BnaSemesterDuration> BnaSemesterDurationRepository, IMapper mapper)
        {
            _BnaSemesterDurationRepository = BnaSemesterDurationRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<BnaSemesterDurationDto>> Handle(GetBnaSemesterDurationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false) 
                throw new ValidationException(validationResult.ToString());




            IQueryable<BnaSemesterDuration> BnaSemesterDurations = _BnaSemesterDurationRepository.FilterWithInclude(x => (String.IsNullOrEmpty(request.QueryParams.SearchText)), "BnaSemester","BnaBatch","Rank", "SemesterLocationTypeNavigation", "CourseDuration.CourseName", "CourseDuration"); 


            var totalCount = BnaSemesterDurations.Count();
            BnaSemesterDurations = BnaSemesterDurations.OrderBy(x => x.BnaSemesterDurationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var BnaSemesterDurationsDtos = _mapper.Map<List<BnaSemesterDurationDto>>(BnaSemesterDurations); 
            var result = new PagedResult<BnaSemesterDurationDto>(BnaSemesterDurationsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result; 
        }
    }
}
