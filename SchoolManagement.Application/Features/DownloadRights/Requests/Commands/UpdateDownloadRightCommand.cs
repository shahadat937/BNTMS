using MediatR;
using SchoolManagement.Application.DTOs.DownloadRight;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DownloadRights.Requests.Commands
{
    public class UpdateDownloadRightCommand : IRequest<Unit>
    {
        public DownloadRightDto DownloadRightDto { get; set; }
    }
}
