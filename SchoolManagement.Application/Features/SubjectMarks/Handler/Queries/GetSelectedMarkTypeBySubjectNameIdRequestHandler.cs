using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.SubjectMarks.Handlers.Queries
{
    public class GetSelectedMarkTypeBySubjectNameIdRequestHandler : IRequestHandler<GetSelectedMarkTypeBySubjectNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SubjectMark> _SubjectMarkRepository;

           
        public GetSelectedMarkTypeBySubjectNameIdRequestHandler(ISchoolManagementRepository<SubjectMark> SubjectMarkRepository, ISchoolManagementRepository<BnaExamMark> BnaExamMarkRepository)
        {
            _SubjectMarkRepository = SubjectMarkRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedMarkTypeBySubjectNameIdRequest request, CancellationToken cancellationToken)
        {
            var ReternModels = new List<SelectedModel>();
            //var BnaExamMarks = _BnaExamMarkRepository.FilterWithInclude(x =>x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.BnaSubjectNameId == request.BnaSubjectNameId, "SubjectMark").ToList();
            //var subjectMarkList = BnaExamMarks.GroupBy(x => x.SubjectMark.MarkTypeId).Select(g => g.FirstOrDefault().SubjectMarkId.ToString()).ToList();
           
            IQueryable<SubjectMark> SubjectMarks = _SubjectMarkRepository.FilterWithInclude(x => x.BnaSubjectNameId == request.BnaSubjectNameId);
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
