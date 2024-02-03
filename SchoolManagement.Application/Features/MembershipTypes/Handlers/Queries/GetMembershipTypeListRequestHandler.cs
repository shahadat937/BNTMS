using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.MembershipTypes;
using SchoolManagement.Application.Features.MembershipTypes.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MembershipTypes.Handlers.Queries
{
    public class GetMembershipTypeListRequestHandler : IRequestHandler<GetMembershipTypeListRequest, PagedResult<MembershipTypeDto>>
    { 

        private readonly ISchoolManagementRepository<MemberShipType> _MembershipTypeRepository;    

        private readonly IMapper _mapper;  
         
        public GetMembershipTypeListRequestHandler(ISchoolManagementRepository<MemberShipType> MembershipTypeRepository, IMapper mapper)
        {
            _MembershipTypeRepository = MembershipTypeRepository; 
            _mapper = mapper;  
        }

        public async Task<PagedResult<MembershipTypeDto>> Handle(GetMembershipTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult.ToString()); 

            IQueryable<MemberShipType> MembershipTypes = _MembershipTypeRepository.FilterWithInclude(x => (x.MembershipTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = MembershipTypes.Count();
            MembershipTypes = MembershipTypes.OrderByDescending(x => x.MembershipTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
              
            var MembershipTypesDtos = _mapper.Map<List<MembershipTypeDto>>(MembershipTypes); 
            var result = new PagedResult<MembershipTypeDto>(MembershipTypesDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;
        }
    }
}
