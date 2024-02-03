using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectTypes.Handlers.Queries
{  
    public class GetSelectedSubjectTypeRequestHandler : IRequestHandler<GetSelectedSubjectTypeRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SubjectType> _SubjectTypeRepository;


        public GetSelectedSubjectTypeRequestHandler(ISchoolManagementRepository<SubjectType> SubjectTypeRepository)
        {
            _SubjectTypeRepository = SubjectTypeRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectTypeRequest request, CancellationToken cancellationToken)
        {
            ICollection<SubjectType> SubjectTypes = await _SubjectTypeRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = SubjectTypes.Select(x => new SelectedModel 
            {
                Text = x.SubjectTypeName,
                Value = x.SubjectTypeId
            }).ToList();
            return selectModels;
        } 
    }
}
