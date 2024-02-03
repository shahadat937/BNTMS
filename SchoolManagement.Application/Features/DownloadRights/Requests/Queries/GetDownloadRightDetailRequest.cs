using MediatR;
using SchoolManagement.Application.DTOs.DownloadRight;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.DownloadRights.Requests.Queries
{
    public class GetDownloadRightDetailRequest : IRequest<DownloadRightDto>
    {
        public int DownloadRightId { get; set; }
    }
}
