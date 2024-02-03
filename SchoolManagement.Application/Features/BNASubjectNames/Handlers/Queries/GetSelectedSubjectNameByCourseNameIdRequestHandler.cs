using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetSelectedSubjectNameByCourseNameIdRequestHandler : IRequestHandler<GetSelectedSubjectNameByCourseNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;


        public GetSelectedSubjectNameByCourseNameIdRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectNameByCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaSubjectName> BnaSubjectNames = _BnaSubjectNameRepository.Where(x=> x.CourseNameId == request.CourseNameId).ToList();
            List<SelectedModel> selectModels = BnaSubjectNames.Select(x => new SelectedModel
            {
                Text = x.SubjectName,
                Value = x.BnaSubjectNameId
            }).ToList();
            return selectModels;
        }
    }
}
