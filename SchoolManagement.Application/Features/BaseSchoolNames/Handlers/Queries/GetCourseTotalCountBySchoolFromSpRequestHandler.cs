﻿using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.BaseSchoolNames.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.BaseSchoolNames.Handlers.Queries
{
    public class GetCourseTotalCountBySchoolFromSpRequestHandler : IRequestHandler<GetCourseTotalCountBySchoolFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<BaseSchoolName> _baseSchoolNameRepository;

        private readonly IMapper _mapper;

        public GetCourseTotalCountBySchoolFromSpRequestHandler(ISchoolManagementRepository<BaseSchoolName> baseSchoolNameRepository, IMapper mapper)
        {
            _baseSchoolNameRepository = baseSchoolNameRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetCourseTotalCountBySchoolFromSpRequest request, CancellationToken cancellationToken)
        {
            DateTime Current = DateTime.Now;

            var spQuery = String.Format("exec [spGetTotalCourseCountBySchool] '{0}'", Current);

            DataTable dataTable = _baseSchoolNameRepository.ExecWithSqlQuery(spQuery);
            return dataTable;

        }
    }
}
