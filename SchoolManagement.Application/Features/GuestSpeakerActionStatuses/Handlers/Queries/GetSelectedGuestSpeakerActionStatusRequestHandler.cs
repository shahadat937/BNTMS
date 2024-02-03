using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Handlers.Queries
{
    public class GetSelectedGuestSpeakerActionStatusRequestHandler : IRequestHandler<GetSelectedGuestSpeakerActionStatusRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<GuestSpeakerActionStatus> _GuestSpeakerActionStatusRepository;


        public GetSelectedGuestSpeakerActionStatusRequestHandler(ISchoolManagementRepository<GuestSpeakerActionStatus> GuestSpeakerActionStatusRepository)
        {
            _GuestSpeakerActionStatusRepository = GuestSpeakerActionStatusRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGuestSpeakerActionStatusRequest request, CancellationToken cancellationToken)
        {
            ICollection<GuestSpeakerActionStatus> codeValues = await _GuestSpeakerActionStatusRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.GuestSpeakerActionStatusId
            }).ToList();
            return selectModels;
        }
    }
}
