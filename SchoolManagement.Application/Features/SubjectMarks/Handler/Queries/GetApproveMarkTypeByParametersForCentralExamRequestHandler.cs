using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectMarks.Handlers.Queries   
{
    public class GetApproveMarkTypeByParametersForCentralExamRequestHandler : IRequestHandler<GetApproveMarkTypeByParametersForCentralExamRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository;
        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

           
        public GetApproveMarkTypeByParametersForCentralExamRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository)
        {
            _SubjectMarkRepository = SubjectMarkRepository;
            _BnaExamMarkRepository = BnaExamMarkRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetApproveMarkTypeByParametersForCentralExamRequest request, CancellationToken cancellationToken)
        {
            var ReternModels = new List<SelectedModel>();
            var BnaExamMarks = _BnaExamMarkRepository.FilterWithInclude(x => x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.SubmissionStatus == 1 && x.IsApproved == request.IsApproved, "SubjectMark").ToList();
            var subjectMarkList = BnaExamMarks.GroupBy(x => x.SubjectMark.MarkTypeId).Select(g => g.FirstOrDefault().SubjectMarkId.ToString()).ToList();

            IQueryable<SubjectMark> SubjectMarks = _SubjectMarkRepository.FilterWithInclude(x => x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId && !subjectMarkList.Contains(x.SubjectMarkId.ToString()));
            ReternModels = new List<SelectedModel>();
            ReternModels = SubjectMarks.Select(x => new SelectedModel
            {
                Text = x.MarkType.TypeName,
                Value = x.SubjectMarkId
            }).ToList();
            return ReternModels;

            //IQueryable<SubjectMark> SubjectMarks = _SubjectMarkRepository.FilterWithInclude(x => x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId, "MarkType");
            //var ReternModels = new List<SelectedModel>();
            //ReternModels = SubjectMarks.Select(x => new SelectedModel
            //{
            //    Text = x.MarkType.TypeName,
            //    Value = x.SubjectMarkId
            //}).ToList();
            //return ReternModels;

        }
    }
}
