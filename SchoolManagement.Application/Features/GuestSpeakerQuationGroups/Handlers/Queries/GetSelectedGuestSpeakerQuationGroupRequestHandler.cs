using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Queries
{
    public class GetSelectedGuestSpeakerQuationGroupRequestHandler : IRequestHandler<GetSelectedGuestSpeakerQuationGroupRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<GuestSpeakerQuationGroup> _GuestSpeakerQuationGroupRepository;


        public GetSelectedGuestSpeakerQuationGroupRequestHandler(ISchoolManagementRepository<GuestSpeakerQuationGroup> GuestSpeakerQuationGroupRepository)
        {
            _GuestSpeakerQuationGroupRepository = GuestSpeakerQuationGroupRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGuestSpeakerQuationGroupRequest request, CancellationToken cancellationToken)
        {
            ICollection<GuestSpeakerQuationGroup> codeValues = await _GuestSpeakerQuationGroupRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.CourseName.Course,
                Value = x.GuestSpeakerQuationGroupId
            }).ToList();
            return selectModels;
        }
    }
}
