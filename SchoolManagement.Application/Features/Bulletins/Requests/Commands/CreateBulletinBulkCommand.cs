using MediatR;
using SchoolManagement.Application.DTOs.Bulletin;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Bulletins.Requests.Commands
{
    public class CreateBulletinBulkCommand: IRequest<BaseCommandResponse>
    {
        public CreateBulletinBulkDto bulletinBulkDto { get; set; }
    }
}
