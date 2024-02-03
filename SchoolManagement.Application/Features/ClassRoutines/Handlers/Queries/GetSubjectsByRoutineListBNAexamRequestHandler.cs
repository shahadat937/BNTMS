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
using SchoolManagement.Application.DTOs.BnaSubjectName;
using System.Data;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetSubjectsByRoutineListBNAexamRequestHandler : IRequestHandler<GetSubjectsByRoutineListBNAexamRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseInstructor> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetSubjectsByRoutineListBNAexamRequestHandler(ISchoolManagementRepository<CourseInstructor> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSubjectsByRoutineListBNAexamRequest request, CancellationToken cancellationToken)
        {
            var spQuery = string.Format("exec [spGetSubjectsByWeeklyRoutineListBNAExam] {0},{1},{2},{3}", request.BaseSchoolNameId, request.CourseNameId, request.CourseWeekId, request.CourseSectionId);

            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
        }
    }
}
