using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Groups.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Groups.Handlers.Queries
{
    public class GetSelectedGroupRequestHandler : IRequestHandler<GetSelectedGroupRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<Group> _GroupRepository;


        public GetSelectedGroupRequestHandler(ISchoolManagementRepository<Group> GroupRepository)
        {
            _GroupRepository = GroupRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGroupRequest request, CancellationToken cancellationToken)
        {
            ICollection<Group> codeValues = await _GroupRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.GroupName,
                Value = x.GroupId
            }).ToList();
            return selectModels;
        }
    }
}
