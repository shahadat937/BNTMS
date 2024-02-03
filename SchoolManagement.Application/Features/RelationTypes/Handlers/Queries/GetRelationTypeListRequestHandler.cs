using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.RelationType;
using SchoolManagement.Application.Features.RelationTypes.Requests;
using SchoolManagement.Application.Features.RelationTypes.Requests.Queries;
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

namespace SchoolManagement.Application.Features.RelationTypes.Handlers.Queries
{
    public class GetRelationTypeListRequestHandler : IRequestHandler<GetRelationTypeListRequest, PagedResult<RelationTypeDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.RelationType> _RelationTypeRepository;

        private readonly IMapper _mapper;

        public GetRelationTypeListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.RelationType> RelationTypeRepository, IMapper mapper)
        {
            _RelationTypeRepository = RelationTypeRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<RelationTypeDto>> Handle(GetRelationTypeListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.RelationType> RelationTypes = _RelationTypeRepository.FilterWithInclude(x => (x.RelationTypeName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = RelationTypes.Count();
            RelationTypes = RelationTypes.OrderByDescending(x => x.RelationTypeId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var RelationTypeDtos = _mapper.Map<List<RelationTypeDto>>(RelationTypes);
            var result = new PagedResult<RelationTypeDto>(RelationTypeDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
