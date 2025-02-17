using MediatR;
using SchoolManagement.Application.DTOs.RoleFeature;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RoleFeatures.Requests.Commands
{
    public class CreateRoleFeaturesCommand : IRequest<BaseCommandResponse>
    {
        public List<CreateRoleFeatureDto> RoleFeatureDtos { get; set; }
    }
}
