using MediatR;
using SchoolManagement.Application.DTOs.DownloadRight;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DownloadRights.Requests.Commands
{
    public class CreateDownloadRightCommand : IRequest<BaseCommandResponse>
    {
        public CreateDownloadRightDto DownloadRightDto { get; set; }
    }
}
