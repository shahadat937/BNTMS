using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeAssignmentSubmits.Requests.Queries;
using SchoolManagement.Application.DTOs.TraineeAssignmentSubmits;

namespace SchoolManagement.Application.Features.TraineeAssignmentSubmits.Handlers.Queries
{
    public class GetTraineeAssignmentSubmitListRequestHandler : IRequestHandler<GetTraineeAssignmentSubmitListRequest, PagedResult<TraineeAssignmentSubmitDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssignmentSubmit> _TraineeAssignmentSubmitRepository;

        private readonly IMapper _mapper;

        public GetTraineeAssignmentSubmitListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeAssignmentSubmit> TraineeAssignmentSubmitRepository, IMapper mapper)
        {
            _TraineeAssignmentSubmitRepository = TraineeAssignmentSubmitRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeAssignmentSubmitDto>> Handle(GetTraineeAssignmentSubmitListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeAssignmentSubmit> TraineeAssignmentSubmits = _TraineeAssignmentSubmitRepository.FilterWithInclude(x => (x.AssignmentTopic.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = TraineeAssignmentSubmits.Count();
            TraineeAssignmentSubmits = TraineeAssignmentSubmits.OrderByDescending(x => x.TraineeAssignmentSubmitId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeAssignmentSubmitDtos = _mapper.Map<List<TraineeAssignmentSubmitDto>>(TraineeAssignmentSubmits);
            var result = new PagedResult<TraineeAssignmentSubmitDto>(TraineeAssignmentSubmitDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
