using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuestionNames.Requests.Queries
{
    public class GetSelectedGuestSpeakerQuestionNameRequest : IRequest<List<SelectedModel>>
    {
    }
}
