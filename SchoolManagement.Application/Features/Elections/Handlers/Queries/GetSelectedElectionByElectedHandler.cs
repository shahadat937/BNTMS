using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Elections.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Elections.Handlers.Queries
{
    public class GetSelectedElectionByTypeHandler : IRequestHandler<GetSelectedElectionByElected, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Election> _ElectionRepository;


        public GetSelectedElectionByTypeHandler(ISchoolManagementRepository<Election> ElectionRepository)
        {
            _ElectionRepository = ElectionRepository;           
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedElectionByElected request, CancellationToken cancellationToken)
        {
            ICollection<Election> Elections = await _ElectionRepository.FilterAsync(x =>x.IsActive);
            List<SelectedModel> selectModels = Elections.Select(x => new SelectedModel
            {
                Text = x.InstituteName,
                Value = x.ElectionId
            }).ToList();
            return selectModels;
        }
    }
}
