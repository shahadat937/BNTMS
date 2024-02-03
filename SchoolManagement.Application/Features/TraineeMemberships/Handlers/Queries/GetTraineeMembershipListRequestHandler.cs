using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeMembership;
using SchoolManagement.Application.Features.TraineeMemberships.Requests;
using SchoolManagement.Application.Features.TraineeMemberships.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

namespace SchoolManagement.Application.Features.TraineeMemberships.Handlers.Queries
{
    public class GetTraineeMembershipListRequestHandler : IRequestHandler<GetTraineeMembershipListRequest, PagedResult<TraineeMembershipDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeMembership> _TraineeMembershipRepository;

        private readonly IMapper _mapper;

        public GetTraineeMembershipListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeMembership> TraineeMembershipRepository, IMapper mapper)
        {
            _TraineeMembershipRepository = TraineeMembershipRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeMembershipDto>> Handle(GetTraineeMembershipListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeMembership> TraineeMemberships = _TraineeMembershipRepository.FilterWithInclude(x => (x.OrgName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = TraineeMemberships.Count();
            TraineeMemberships = TraineeMemberships.OrderByDescending(x => x.TraineeMembershipId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            //var TraineeMembershipDtos = _mapper.Map<List<TraineeMembershipDto>>(TraineeMemberships);
            var TraineeMembershipDtos = _mapper.Map<List<TraineeMembershipDto>>(TraineeMemberships);
            var result = new PagedResult<TraineeMembershipDto>(TraineeMembershipDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
