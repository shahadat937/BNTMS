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
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationListByBnaSemesterDurationIdRequestHandler : IRequestHandler<GetTraineeNominationListByBnaSemesterDurationIdRequest, PagedResult<TraineeNominationDto>>
    {
         
        private readonly ISchoolManagementRepository<TraineeNomination> _TraineeNominationRepository;

        private readonly IMapper _mapper;

        public GetTraineeNominationListByBnaSemesterDurationIdRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.TraineeNomination> TraineeNominationRepository, IMapper mapper)
        {
            _TraineeNominationRepository = TraineeNominationRepository;
            _mapper = mapper;
        }

        public async Task<PagedResult<TraineeNominationDto>> Handle(GetTraineeNominationListByBnaSemesterDurationIdRequest request, CancellationToken cancellationToken)
        {
            var validator = new QueryParamsValidator();
            var validationResult = await validator.ValidateAsync(request.QueryParams);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

          //  IQueryable<SchoolManagement.Domain.Board> Boards = _BoardRepository.FilterWithInclude(x => (x.BoardName.Contains(request.QueryParams.SearchText) || String.IsNullOrEmpty(request.QueryParams.SearchText)));
            IQueryable<TraineeNomination> TraineeNominations = _TraineeNominationRepository.FilterWithInclude(x => (x.Trainee.Pno.Contains(request.QueryParams.SearchText) ||  String.IsNullOrEmpty(request.QueryParams.SearchText)), "CourseDuration", "CourseDuration.BaseSchoolName", "CourseName", "TraineeCourseStatus", "WithdrawnDoc", "Trainee.Rank", "Trainee.SaylorBranch", "ExamCenter", "NewAtempt").Where(x => x.BnaSemesterDurationId == request.BnaSemesterDurationId);
            var totalCount = TraineeNominations.Count();
            TraineeNominations = TraineeNominations.OrderBy(x => x.Trainee.Pno).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);
           // Boards = Boards.OrderByDescending(x => x.BoardId).Skip((request.QueryParams.PageNumber - 1) * request.QueryParams.PageSize).Take(request.QueryParams.PageSize);

            var TraineeNominationDtos = _mapper.Map<List<TraineeNominationDto>>(TraineeNominations);
            var result = new PagedResult<TraineeNominationDto>(TraineeNominationDtos, totalCount, request.QueryParams.PageNumber, request.QueryParams.PageSize);

            return result;


        }
    }
}
