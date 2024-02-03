using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Handlers.Queries
{ 
    public class GetSelectedUtofficerCategoryRequestHandler : IRequestHandler<GetSelectedUtofficerCategoryRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<UtofficerCategory> _UtofficerCategoryRepository;


        public GetSelectedUtofficerCategoryRequestHandler(ISchoolManagementRepository<UtofficerCategory> UtofficerCategoryRepository)
        {
            _UtofficerCategoryRepository = UtofficerCategoryRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedUtofficerCategoryRequest request, CancellationToken cancellationToken)
        {
            ICollection<UtofficerCategory> UtofficerCategorys = await _UtofficerCategoryRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = UtofficerCategorys.Select(x => new SelectedModel 
            {
                Text = x.UtofficerCategoryName,
                Value = x.UtofficerCategoryId
            }).ToList();
            return selectModels;
        }
    }
}
