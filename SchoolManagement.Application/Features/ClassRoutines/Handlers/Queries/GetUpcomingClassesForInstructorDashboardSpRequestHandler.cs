﻿using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetUpcomingClassesForInstructorDashboardSpRequestHandler : IRequestHandler<GetUpcommingClassesForInstructorDashboardSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _routineRepository;

        private readonly IMapper _mapper;

        public GetUpcomingClassesForInstructorDashboardSpRequestHandler(ISchoolManagementRepository<ClassRoutine> routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetUpcommingClassesForInstructorDashboardSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetUpcomingClassesForInstructorDashboard] '{0}', {1}", request.CurrentDate,request.TraineeId);
            
            DataTable dataTable = _routineRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
