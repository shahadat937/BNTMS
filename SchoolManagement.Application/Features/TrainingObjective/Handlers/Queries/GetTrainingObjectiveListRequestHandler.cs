using SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingObjective;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;

using System.Text;


namespace SchoolManagement.Application.Features.TrainingObjectives.Handlers.Queries
{
    public class GetTrainingObjectiveListRequestHandler : IRequestHandler<GetTrainingObjectiveListRequest, PagedResult<TrainingObjectiveDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TrainingObjective> _TrainingObjectiveRepository;

        private readonly IMapper _mapper;

        public GetTrainingObjectiveListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TrainingObjective> TrainingObjectiveRepository, IMapper mapper)
        {
            _TrainingObjectiveRepository = TrainingObjectiveRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TrainingObjectiveDto>> Handle(GetTrainingObjectiveListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TrainingObjective> TrainingObjectives = _TrainingObjectiveRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText));
            var totalCount = TrainingObjectives.Count();
            TrainingObjectives = TrainingObjectives.OrderByDescending(x => x.TrainingObjectiveId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TrainingObjectiveDtos = _mapper.Map<List<TrainingObjectiveDto>>(TrainingObjectives);
            var result = new PagedResult<TrainingObjectiveDto>(TrainingObjectiveDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
