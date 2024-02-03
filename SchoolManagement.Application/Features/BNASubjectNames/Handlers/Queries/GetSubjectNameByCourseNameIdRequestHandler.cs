using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{
    public class GetSubjectNameByCourseNameIdRequestHandler : IRequestHandler<GetSubjectNameByCourseNameIdRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;

          
        public GetSubjectNameByCourseNameIdRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetSubjectNameByCourseNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaSubjectName> BnaSubjectNames = await _BnaSubjectNameRepository.FilterAsync(x=>x.CourseNameId == request.CourseNameId);
            List<SelectedModel> selectModels = BnaSubjectNames.Select(x => new SelectedModel
            {
                Text = x.SubjectName, 
                Value = x.BnaSubjectNameId 
            }).ToList();
            return selectModels;
        }
    }
}
