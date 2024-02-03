using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic; 
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectClassifications.Handlers.Queries
{  
    public class GetSelectedSubjectClassificationRequestHandler : IRequestHandler<GetSelectedSubjectClassificationRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SubjectClassification> _SubjectClassificationRepository;


        public GetSelectedSubjectClassificationRequestHandler(ISchoolManagementRepository<SubjectClassification> SubjectClassificationRepository)
        {
            _SubjectClassificationRepository = SubjectClassificationRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectClassificationRequest request, CancellationToken cancellationToken)
        {
            ICollection<SubjectClassification> SubjectClassifications = await _SubjectClassificationRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = SubjectClassifications.Select(x => new SelectedModel 
            {
                Text = x.SubjectClassificationName,
                Value = x.SubjectClassificationId
            }).ToList();
            return selectModels;
        } 
    }
}
