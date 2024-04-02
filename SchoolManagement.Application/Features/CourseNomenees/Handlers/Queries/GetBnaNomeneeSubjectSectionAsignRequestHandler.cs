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
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Queries
{
    public class GetBnaNomeneeSubjectSectionAsignRequestHandler :IRequestHandler<GetBnaNomeneeSubjectSectionAsignRequest, object>
    {

        private readonly ISchoolManagementRepository<BnaSubjectName> _bnaSubjectNameRepository;

    private readonly IMapper _mapper;

    public GetBnaNomeneeSubjectSectionAsignRequestHandler(ISchoolManagementRepository<BnaSubjectName> bnaSubjectNameRepository, IMapper mapper)
    {
        _bnaSubjectNameRepository = bnaSubjectNameRepository;
        _mapper = mapper;
    }

    public async Task<object> Handle(GetBnaNomeneeSubjectSectionAsignRequest request, CancellationToken cancellationToken)
    {

        IQueryable<BnaSubjectName> subjectNames = _bnaSubjectNameRepository.Where(x => x.BaseSchoolNameId == request.schollNameId && x.CourseNameId == request.courseNameId && x.BnaSubjectCurriculumId == request.bnaSubjectCurriculumId && x.BnaSemesterId == request.bnaSemesterId);


            List<SelectedModel> selectModels = subjectNames.Select(x => new SelectedModel
            {
                Text = x.SubjectName,
                Value = x.BnaSubjectNameId
            }).ToList();

            return selectModels;

    }
}
}
