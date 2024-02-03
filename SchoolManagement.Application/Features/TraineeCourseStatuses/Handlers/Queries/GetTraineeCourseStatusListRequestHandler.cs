using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.TraineeCourseStatus;
using SchoolManagement.Application.Features.TraineeCourseStatuses.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeCourseStatuses.Handlers.Queries
{
    public class GetTraineeCourseStatusesListRequestHandler : IRequestHandler<GetTraineeCourseStatusesListRequest, PagedResult<TraineeCourseStatusDto>>
    { 

        private readonly ISchoolManagementRepository<TraineeCourseStatus> _TraineeCourseStatusRepository;    

        private readonly IMapper _mapper;  
         
        public GetTraineeCourseStatusesListRequestHandler(ISchoolManagementRepository<TraineeCourseStatus> TraineeCourseStatusRepository, IMapper mapper)
        {
            _TraineeCourseStatusRepository = TraineeCourseStatusRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<TraineeCourseStatusDto>> Handle(GetTraineeCourseStatusesListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<TraineeCourseStatus> TraineeCourseStatuses = _TraineeCourseStatusRepository.FilterWithInclude(x => (x.TraineeCourseStatusName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = TraineeCourseStatuses.Count();
            TraineeCourseStatuses = TraineeCourseStatuses.OrderByDescending(x => x.TraineeCourseStatusId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var TraineeCourseStatusesDtos = _mapper.Map<List<TraineeCourseStatusDto>>(TraineeCourseStatuses); 
            var result = new PagedResult<TraineeCourseStatusDto>(TraineeCourseStatusesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
