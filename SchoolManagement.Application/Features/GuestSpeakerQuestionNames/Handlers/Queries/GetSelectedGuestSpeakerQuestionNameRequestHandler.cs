using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Handlers.Queries
{
    public class GetSelectedGuestSpeakerQuestionNameRequestHandler : IRequestHandler<GetSelectedGuestSpeakerQuestionNameRequest, List<SelectedModel>>
    {
        private readonly ISchoolManagementRepository<GuestSpeakerQuestionName> _GuestSpeakerQuestionNameRepository;


        public GetSelectedGuestSpeakerQuestionNameRequestHandler(ISchoolManagementRepository<GuestSpeakerQuestionName> GuestSpeakerQuestionNameRepository)
        {
            _GuestSpeakerQuestionNameRepository = GuestSpeakerQuestionNameRepository;
        }

        public async Task<List<SelectedModel>> Handle(GetSelectedGuestSpeakerQuestionNameRequest request, CancellationToken cancellationToken)
        {
            ICollection<GuestSpeakerQuestionName> codeValues = await _GuestSpeakerQuestionNameRepository.FilterAsync(x => x.IsActive);
            List<SelectedModel> selectModels = codeValues.Select(x => new SelectedModel
            {
                Text = x.Name,
                Value = x.GuestSpeakerQuestionNameId
            }).ToList();
            return selectModels;
        }
    }
}
