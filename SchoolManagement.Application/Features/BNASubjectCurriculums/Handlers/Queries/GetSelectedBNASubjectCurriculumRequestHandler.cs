using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectCurriculums.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectCurriculums.Handlers.Queries
{ 
    public class GetSelectedBnaSubjectCurriculumRequestHandler : IRequestHandler<GetSelectedBnaSubjectCurriculumRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<BnaSubjectCurriculum> _BnaSubjectCurriculumRepository;


        public GetSelectedBnaSubjectCurriculumRequestHandler(ISchoolManagementRepository<BnaSubjectCurriculum> BnaSubjectCurriculumRepository)
        {
            _BnaSubjectCurriculumRepository = BnaSubjectCurriculumRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedBnaSubjectCurriculumRequest request, CancellationToken cancellationToken)
        {
            ICollection<BnaSubjectCurriculum> BnaSubjectCurriculums = await _BnaSubjectCurriculumRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = BnaSubjectCurriculums.Select(x => new SelectedModel 
            {
                Text = x.SubjectCurriculumName, 
                Value = x.BnaSubjectCurriculumId
            }).ToList();
            return selectModels;
        }
    }
}
