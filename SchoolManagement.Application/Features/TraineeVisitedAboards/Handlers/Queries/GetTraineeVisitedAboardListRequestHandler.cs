using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeVisitedAboard;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests;
using SchoolManagement.Application.Features.TraineeVisitedAboards.Requests.Queries;
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

namespace SchoolManagement.Application.Features.TraineeVisitedAboards.Handlers.Queries
{
    public class GetTraineeVisitedAboardListRequestHandler : IRequestHandler<GetTraineeVisitedAboardListRequest, PagedResult<TraineeVisitedAboardDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeVisitedAboard> _TraineeVisitedAboardRepository;

        private readonly IMapper _mapper;

        public GetTraineeVisitedAboardListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeVisitedAboard> TraineeVisitedAboardRepository, IMapper mapper)
        {
            _TraineeVisitedAboardRepository = TraineeVisitedAboardRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeVisitedAboardDto>> Handle(GetTraineeVisitedAboardListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeVisitedAboard> TraineeVisitedAboards = _TraineeVisitedAboardRepository.FilterWithInclude(x => (x.PurposeOfVisit.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            var totalCount = TraineeVisitedAboards.Count();
            TraineeVisitedAboards = TraineeVisitedAboards.OrderByDescending(x => x.TraineeVisitedAboardId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeVisitedAboardDtos = _mapper.Map<List<TraineeVisitedAboardDto>>(TraineeVisitedAboards);
            var result = new PagedResult<TraineeVisitedAboardDto>(TraineeVisitedAboardDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
