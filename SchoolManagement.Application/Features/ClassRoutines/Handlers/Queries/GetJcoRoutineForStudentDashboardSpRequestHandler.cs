﻿using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetJcoRoutineForStudentDashboardSpRequestHandler : IRequestHandler<GetJcoRoutineForStudentDashboardSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _routineRepository;

        private readonly IMapper _mapper;

        public GetJcoRoutineForStudentDashboardSpRequestHandler(ISchoolManagementRepository<ClassRoutine> routineRepository, IMapper mapper)
        {
            _routineRepository = routineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetJcoRoutineForStudentDashboardSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetJcoRoutineForStudentDashboard] '{0}', {1},{2},{3}", request.CurrentDate,request.CourseDurationId,request.SaylorBranchId,request.SaylorSubBranchId);
            
            DataTable dataTable = _routineRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
