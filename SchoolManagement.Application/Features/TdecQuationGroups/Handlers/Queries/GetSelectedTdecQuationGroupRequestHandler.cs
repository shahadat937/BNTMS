using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Queries
{
    public class GetSelectedTdecQuationGroupRequestHandler : IRequestHandler<GetSelectedTdecQuationGroupRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<TdecQuationGroup> _TdecQuationGroupRepository;


        public GetSelectedTdecQuationGroupRequestHandler(ISchoolManagementRepository<TdecQuationGroup> TdecQuationGroupRepository)
        {
            _TdecQuationGroupRepository = TdecQuationGroupRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedTdecQuationGroupRequest request, CancellationToken cancellationToken)
        {
            ICollection<TdecQuationGroup> codeValues = await _TdecQuationGroupRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course,
                Value = x.TdecQuationGroupId
            }).ToList();
            return selectModels;
        }
    }
}
