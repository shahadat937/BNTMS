using MediatR;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.FamilyInfos.Requests.Commands
{
    public class CreateFamilyInfoCommand : IRequest<BaseCommandResponse>
    {
        public CreateFamilyInfoDto FamilyInfoDto { get; set; }
    }
}
 