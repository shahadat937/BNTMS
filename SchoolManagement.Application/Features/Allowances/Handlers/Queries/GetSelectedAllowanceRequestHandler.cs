using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Allowances.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Allowances.Handlers.Queries
{
    public class GetSelectedAllowanceRequestHandler : IRequestHandler<GetSelectedAllowanceRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Allowance> _AllowanceRepository;


        public GetSelectedAllowanceRequestHandler(ISchoolManagementRepository<Allowance> AllowanceRepository)
        {
            _AllowanceRepository = AllowanceRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedAllowanceRequest request, CancellationToken cancellationToken)
        {
            ICollection<Allowance> Allowances = await _AllowanceRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = Allowances.Select(x => new SelectedModel 
            {
                Text = x.Vacancy,
                Value = x.AllowanceId
            }).ToList();
            return selectModels;
        }
    }
}
