using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using System.Data;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries 
{ 
    public class GetSubjectListBySchoolAndCourseRequestHandler : IRequestHandler<GetSubjectListBySchoolAndCourseRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetSubjectListBySchoolAndCourseRequestHandler(ISchoolManagementRepository<CourseInstructor> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSubjectListBySchoolAndCourseRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetInstructorBySubjectList] {0},{1},{2},{3},{4}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.CourseWeekId, request.CourseSectionId);

            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
