using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.TraineeNominations.Requests;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
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

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationListRequestHandler : IRequestHandler<GetTraineeNominationListRequest, PagedResult<TraineeNominationDto>>
    {

        private readonly ISchoolManagementRepository<SchoolManagement.Domain.TraineeNomination> _TraineeNominationRepository;

        private readonly IMapper _mapper;

        public GetTraineeNominationListRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeNomination> TraineeNominationRepository, IMapper mapper)
        {
            _TraineeNominationRepository = TraineeNominationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeNominationDto>> Handle(GetTraineeNominationListRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            IQueryable<SchoolManagement.Domain.TraineeNomination> TraineeNominations = _TraineeNominationRepository.FilterWithInclude(x =>  String.IsNullOrEmpty(request.QueryParams.SearchText), "CourseDuration", "CourseName", "TraineeCourseStatus", "WithdrawnDoc", "Trainee", "ExamCenter");
            var totalCount = TraineeNominations.Count();
            TraineeNominations = TraineeNominations.OrderByDescending(x => x.TraineeNominationId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(TraineeNominations);
            var result = new PagedResult<TraineeNominationDto>(TraineeNominationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
