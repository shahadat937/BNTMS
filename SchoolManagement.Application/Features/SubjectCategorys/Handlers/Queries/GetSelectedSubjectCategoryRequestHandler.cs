using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.SubjectCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectCategorys.Handlers.Queries  
{ 
    public class GetSelectedSubjectCategoryRequestHandler : IRequestHandler<GetSelectedSubjectCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<SubjectCategory> _SubjectCategoryRepository;

        public GetSelectedSubjectCategoryRequestHandler(ISchoolManagementRepository<SubjectCategory> SubjectCategoryRepository)
        {
            _SubjectCategoryRepository = SubjectCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedSubjectCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<SubjectCategory> SubjectCategory = await _SubjectCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = SubjectCategory.Select(x => new SelectedModel 
            {
                Text = x.SubjectCategoryName,
                Value = x.SubjectCategoryId
            }).ToList();
            return selectModels;
        }
    }
} 
