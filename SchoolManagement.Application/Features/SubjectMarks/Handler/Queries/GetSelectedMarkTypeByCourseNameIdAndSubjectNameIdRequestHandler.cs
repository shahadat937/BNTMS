using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SubjectMarks.Handlers.Queries
{
    public class GetSelectedMarkTypeByCourseNameIdAndSubjectNameIdRequestHandler : IRequestHandler<GetSelectedMarkTypeByCourseNameIdAndSubjectNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository;
        private readonly ISchoolManagementRepository<BnaExamMark> _BnaExamMarkRepository;

           
        public GetSelectedMarkTypeByCourseNameIdAndSubjectNameIdRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository)
        {
            _SubjectMarkRepository = SubjectMarkRepository;
            _BnaExamMarkRepository = BnaExamMarkRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMarkTypeByCourseNameIdAndSubjectNameIdRequest request, CancellationToken cancellationToken)
        {
            var ReternModels = new List<SelectedModel>();
            var BnaExamMarks = _BnaExamMarkRepository.FilterWithInclude(x =>x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId, "SubjectMark").ToList();
            var subjectMarkList = BnaExamMarks.GroupBy(x => x.SubjectMark.MarkTypeId).Select(g => g.FirstOrDefault().SubjectMarkId.ToString()).ToList();
           
            IQueryable<SubjectMark> SubjectMarks = _SubjectMarkRepository.FilterWithInclude(x => x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId && !subjectMarkList.Contains(x.SubjectMarkId.ToString()));
            ReternModels = new List<SelectedModel>();
            ReternModels = SubjectMarks.Select(x => new SelectedModel
            {
                Text = x.MarkType.TypeName,
                Value = x.SubjectMarkId
            }).ToList();
            return ReternModels;
            
        }
    }
}
