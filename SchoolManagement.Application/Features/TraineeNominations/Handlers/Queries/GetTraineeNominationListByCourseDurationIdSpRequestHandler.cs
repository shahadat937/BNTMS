﻿using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries
{
    public class GetTraineeNominationListByCourseDurationIdSpRequestHandler : IRequestHandler<GetTraineeNominationListByCourseDurationIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeNomination> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;
         
        public GetTraineeNominationListByCourseDurationIdSpRequestHandler(ISchoolManagementRepository<TraineeNomination> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeNominationListByCourseDurationIdSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetTraineeNominationListByCourseDurationId] {0}", request.CourseDurationId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
