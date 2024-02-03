using MediatR;
using SchoolManagement.Application.DTOs.FamilyInfo;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Commands
{
    public class UpdateFamilyInfoCommand : IRequest<Unit>
    {
        public FamilyInfoDto FamilyInfoDto { get; set; }
    }
}
 