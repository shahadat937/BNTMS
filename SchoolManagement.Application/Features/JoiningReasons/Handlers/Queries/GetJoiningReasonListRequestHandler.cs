using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.JoiningReasons;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.JoiningReasons.Requests.Queries;

namespace SchoolManagement.Application.Features.JoiningReasons.Handlers.Queries
{
    public class GetJoiningReasonListRequestHandler : IRequestHandler<GetJoiningReasonListRequest, PagedResult<JoiningReasonDto>>
    { 

        private readonly ISchoolManagementRepository<JoiningReason> _JoiningReasonRepository;    

        private readonly IMapper _mapper;  
         
        public GetJoiningReasonListRequestHandler(ISchoolManagementRepository<JoiningReason> JoiningReasonRepository, IMapper mapper)
        {
            _JoiningReasonRepository = JoiningReasonRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<JoiningReasonDto>> Handle(GetJoiningReasonListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<JoiningReason> JoiningReasons = _JoiningReasonRepository.FilterWithInclude(x => (x.IfAnotherReason.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = JoiningReasons.Count();
            JoiningReasons = JoiningReasons.OrderByDescending(x => x.JoiningReasonId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var JoiningReasonsDtos = _mapper.Map<List<JoiningReasonDto>>(JoiningReasons); 
            var result = new PagedResult<JoiningReasonDto>(JoiningReasonsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
