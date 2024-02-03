using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerActionStatuses.Requests.Queries
{
    public class GetSelectedGuestSpeakerActionStatusRequest : IRequest<List<SelectedModel>>
    {
    }
}
