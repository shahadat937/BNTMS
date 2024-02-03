using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Queries
{
    public class GetSelectedGuestSpeakerQuationGroupRequest : IRequest<List<SelectedModel>>
    {
    }
}
