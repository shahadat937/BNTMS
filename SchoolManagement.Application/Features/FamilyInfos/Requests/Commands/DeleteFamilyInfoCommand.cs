using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Commands
{
    public class DeleteFamilyInfoCommand : IRequest
    {
        public int FamilyInfoId { get; set; }
    }
}
 