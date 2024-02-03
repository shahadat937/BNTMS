﻿using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetCourseDurationListForNbcdFromSpRequestHandler : IRequestHandler<GetCourseDurationListForNbcdFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetCourseDurationListForNbcdFromSpRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCourseDurationListForNbcdFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetNbcdCourseCreate] '{0}',{1}", request.CurrentDate, request.NbcdSchoolId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
