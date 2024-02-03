using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.WeekNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.WeekNames.Handlers.Queries
{
    public class GetSelectedWeekNameRequestHandler : IRequestHandler<GetSelectedWeekNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<WeekName> _WeekNameRepository;


        public GetSelectedWeekNameRequestHandler(ISchoolManagementRepository<WeekName> WeekNameRepository)
        {
            _WeekNameRepository = WeekNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedWeekNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<WeekName> codeValues = await _WeekNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.WeekNameId
            }).ToList();
            return selectModels;
        }
    }
}
