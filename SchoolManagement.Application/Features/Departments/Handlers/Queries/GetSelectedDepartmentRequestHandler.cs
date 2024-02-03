using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Departments.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Departments.Handlers.Queries
{ 
    public class GetSelectedDepartmentRequestHandler : IRequestHandler<GetSelectedDepartmentRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Department> _DepartmentRepository;


        public GetSelectedDepartmentRequestHandler(ISchoolManagementRepository<Department> DepartmentRepository)
        {
            _DepartmentRepository = DepartmentRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedDepartmentRequest request, CancellationToken cancellationToken)
        {
            ICollection<Department> Departments = await _DepartmentRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = Departments.Select(x => new SelectedModel 
            {
                Text = x.DepartmentName,
                Value = x.DepartmentId
            }).ToList();
            return selectModels;
        }
    }
}
