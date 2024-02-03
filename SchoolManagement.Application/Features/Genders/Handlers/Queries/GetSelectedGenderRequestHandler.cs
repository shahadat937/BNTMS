using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Genders.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Genders.Handlers.Queries
{
    public class GetSelectedGenderRequestHandler : IRequestHandler<GetSelectedGenderRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Gender> _GenderRepository;


        public GetSelectedGenderRequestHandler(ISchoolManagementRepository<Gender> GenderRepository)
        {
            _GenderRepository = GenderRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGenderRequest request, CancellationToken cancellationToken)
        {
            ICollection<Gender> codeValues = await _GenderRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.GenderName,
                Value = x.GenderId
            }).ToList();
            return selectModels;
        }
    }
}
