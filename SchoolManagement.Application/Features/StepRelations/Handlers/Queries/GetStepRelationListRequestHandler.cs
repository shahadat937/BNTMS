using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.StepRelation;
using SchoolManagement.Application.Features.StepRelations.Requests;
using SchoolManagement.Application.Features.StepRelations.Requests.Queries;
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

namespace SchoolManagement.Application.Features.StepRelations.Handlers.Queries
{
    public class GetStepRelationListRequestHandler : IRequestHandler<GetStepRelationListRequest, PagedResult<StepRelationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.StepRelation> _StepRelationRepository;

        private readonly IMapper _mapper;

        public GetStepRelationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.StepRelation> StepRelationRepository, IMapper mapper)
        {
            _StepRelationRepository = StepRelationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<StepRelationDto>> Handle(GetStepRelationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.StepRelation> StepRelations = _StepRelationRepository.FilterWithInclude(x => (x.StepRelationType.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = StepRelations.Count();
            StepRelations = StepRelations.OrderByDescending(x => x.StepRelationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var StepRelationDtos = _mapper.Map<List<StepRelationDto>>(StepRelations);
            var result = new PagedResult<StepRelationDto>(StepRelationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
