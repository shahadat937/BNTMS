using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.KindOfSubjects.Handlers.Queries
{  
    public class GetSelectedKindOfSubjectRequestHandler : IRequestHandler<GetSelectedKindOfSubjectRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<KindOfSubject> _KindOfSubjectRepository;

        public GetSelectedKindOfSubjectRequestHandler(ISchoolManagementRepository<KindOfSubject> KindOfSubjectRepository)
        {
            _KindOfSubjectRepository = KindOfSubjectRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedKindOfSubjectRequest request, CancellationToken cancellationToken)
        {
            ICollection<KindOfSubject> KindOfSubjects = await _KindOfSubjectRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = KindOfSubjects.Select(x => new SelectedModel 
            {
                Text = x.KindOfSubjectName,
                Value = x.KindOfSubjectId
            }).ToList();
            return selectModels;
        } 
    }
}
