using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.Groups;
using SchoolManagement.Application.Features.Groups.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Groups.Handlers.Queries
{
    public class GetGroupListRequestHandler : IRequestHandler<GetGroupListRequest, PagedResult<GroupDto>>
    { 

        private readonly ISchoolManagementRepository<Group> _GroupRepository;    

        private readonly IMapper _mapper;  
         
        public GetGroupListRequestHandler(ISchoolManagementRepository<Group> GroupRepository, IMapper mapper)
        {
            _GroupRepository = GroupRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<GroupDto>> Handle(GetGroupListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<Group> Groups = _GroupRepository.FilterWithInclude(x => (x.GroupName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = Groups.Count();
            Groups = Groups.OrderByDescending(x => x.GroupId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var GroupsDtos = _mapper.Map<List<GroupDto>>(Groups); 
            var result = new PagedResult<GroupDto>(GroupsDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
