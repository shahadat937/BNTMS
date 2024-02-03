using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Nationalitys.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Nationalitys.Handlers.Queries
{
    public class GetSelectedNationalityRequestHandler : IRequestHandler<GetSelectedNationalityRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Nationality> _NationalityRepository;


        public GetSelectedNationalityRequestHandler(ISchoolManagementRepository<Nationality> NationalityRepository)
        {
            _NationalityRepository = NationalityRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedNationalityRequest request, CancellationToken cancellationToken)
        {
            ICollection<Nationality> codeValues = await _NationalityRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.NationalityName,
                Value = x.NationalityId
            }).ToList();
            return selectModels;
        }
    }
}
