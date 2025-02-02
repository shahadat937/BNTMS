﻿using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Attendances.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Queries
{
    public class GetTraineeAttendanceListSpRequestHandler : IRequestHandler<GetTraineeAttendanceListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<Attendance> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetTraineeAttendanceListSpRequestHandler(ISchoolManagementRepository<Attendance> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTraineeAttendanceListSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            //var spQuery = String.Format("exec [spGetTraineeAttendanceList] {0},{1},{2},{3}", request.TraineeId,request.CourseDurationId, request.CourseSectionId,request.AttendanceStatus);
            var spQuery = String.Format("exec [spGetTraineeAttendanceList] {0},{1},{2}", request.TraineeId,request.CourseDurationId, request.AttendanceStatus);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
