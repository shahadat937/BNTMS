﻿using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeNomination;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{ 
    public class GetTraineeNominationDetailByCourseDurationIdRequestHandler : IRequestHandler<GetTraineeNominationDetailByCourseDurationIdRequest, TraineeNominationDto[]>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<TraineeNomination> _traineeNominationRepository;  
        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;  
        public GetTraineeNominationDetailByCourseDurationIdRequestHandler(
            ISchoolManagementRepository<TraineeNomination> traineeNominationRepository,
            ISchoolManagementRepository<CourseDuration> courseDurationRepository, 
            IMapper mapper)
        {
            _traineeNominationRepository = traineeNominationRepository; 
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper; 
        }
        //public async Task<TraineeNominationDto> Handle(GetTraineeNominationDetailByCourseDurationIdRequest request, CancellationToken cancellationToken)
        //{
        //    var courseDuration = await _courseDurationRepository.FindOneAsync(x => x.CourseDurationId == request.CourseDurationId);
        //    var value= _mapper.Map<TraineeNominationDto>(courseDuration);
        //    return value;
        //}
        public async Task<TraineeNominationDto[]> Handle(GetTraineeNominationDetailByCourseDurationIdRequest request, CancellationToken cancellationToken)
        {
            // Fetch multiple course duration records based on the given predicate
            var courseDurations = await _courseDurationRepository.FilterAsync(x => x.CourseDurationId == request.CourseDurationId);

            // Map the list of course durations to an array of TraineeNominationDto
            var values = _mapper.Map<TraineeNominationDto[]>(courseDurations);

            // Return the array of TraineeNominationDto
            return values;
        }
    }
}
