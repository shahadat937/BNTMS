using MediatR;
using SchoolManagement.Application.DTOs.RoleFeature;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RoleFeatures.Requests.Queries
{
    public class GetRoleFeaturesByRoleIdRequest : IRequest<List<RoleFeaturesDto>>
    {
        public string Id { get; set; }
    }
}
