using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Electeds.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Electeds.Handlers.Queries
{
    public class GetSelectedElectedRequestHandler : IRequestHandler<GetSelectedElectedRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Elected> _ElectedRepository;


        public GetSelectedElectedRequestHandler(ISchoolManagementRepository<Elected> ElectedRepository)
        {
            _ElectedRepository = ElectedRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedElectedRequest request, CancellationToken cancellationToken)
        {
            ICollection<Elected> codeValues = await _ElectedRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.ElectedType,
                Value = x.ElectedId
            }).ToList();
            return selectModels;
        }
    }
}
