using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Queries;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Queries
{
    public class GetBnaNomeneeSubjectSectionAsignRequestHandler :IRequestHandler<GetBnaNomeneeSubjectSectionAsignRequest, object>
    {

        private readonly ISchoolManagementRepository<TraineeAssessmentMark> _TraineeAssessmentMarkRepository;

    private readonly IMapper _mapper;

    public GetBnaNomeneeSubjectSectionAsignRequestHandler(ISchoolManagementRepository<TraineeAssessmentMark> TraineeAssessmentMarkRepository, IMapper mapper)
    {
        _TraineeAssessmentMarkRepository = TraineeAssessmentMarkRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(GetBnaNomeneeSubjectSectionAsignRequest request, CancellationToken cancellationToken)
    {

        var spQuery = String.Format("exec [spGetCourseSubjectSctionNomenee] {0}", request.traineeNominationId);

        DataTable dataTable = _TraineeAssessmentMarkRepository.ExecWithSqlQuery(spQuery);

        return dataTable;

    }
}
}
