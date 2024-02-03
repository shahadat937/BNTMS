using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DownloadRights.Requests.Commands
{
    public class DeleteDownloadRightCommand : IRequest
    {
        public int DownloadRightId { get; set; }
    }
}
