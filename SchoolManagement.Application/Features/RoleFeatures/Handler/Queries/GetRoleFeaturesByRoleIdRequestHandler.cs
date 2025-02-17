using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RoleFeature;
using SchoolManagement.Application.Features.RoleFeatures.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RoleFeatures.Handler.Queries
{
    public class GetRoleFeaturesByRoleIdRequestHandler : IRequestHandler<GetRoleFeaturesByRoleIdRequest, List<RoleFeaturesDto>>
    {
        private readonly ISchoolManagementRepository<AspNetRoles> _aspNetRolesRepository;
        private readonly ISchoolManagementRepository<RoleFeature> _roleFeatureRepository;
        private readonly ISchoolManagementRepository<Feature> _featuresRepository;
        private readonly ISchoolManagementRepository<Module> _moduleRepository;
        public GetRoleFeaturesByRoleIdRequestHandler(ISchoolManagementRepository<RoleFeature> roleFeatureRepository, ISchoolManagementRepository<Feature> featuresRepository, ISchoolManagementRepository<Module> moduleRepository, ISchoolManagementRepository<AspNetRoles> aspNetRolesRepository)
        {
            _roleFeatureRepository = roleFeatureRepository;
            _featuresRepository = featuresRepository;
            _moduleRepository = moduleRepository;
            _aspNetRolesRepository = aspNetRolesRepository;
        }
        public async Task<List<RoleFeaturesDto>> Handle(GetRoleFeaturesByRoleIdRequest request, CancellationToken cancellationToken)
        {
            var allFeatures = await _featuresRepository.FilterWithInclude(x => true, "Module").ToListAsync();
            var roleName = await _aspNetRolesRepository.FindOneAsync(x => x.Id == request.Id);
            var roleFeatures = await _roleFeatureRepository.FilterWithInclude(x => x.RoleId == request.Id).ToListAsync();
            var result = allFeatures.Select(f =>
            {
                var roleFeature = roleFeatures.FirstOrDefault(rf => rf.FeatureKey == f.FeatureId);
                return new RoleFeaturesDto
                {
    
                    RoleId = roleFeature?.RoleId ?? "",
                    RoleName = roleName.Name,
                    FeatureKey = roleFeature?.FeatureKey ?? 0,
                    FeatureName = f.FeatureName,
                    FeatureId = f.FeatureId,
                    ModuleId = f.ModuleId,
                    ModuleName = f.Module.ModuleName,
                    Add = roleFeature?.Add ?? false,
                    Update = roleFeature?.Update ?? false,
                    Delete = roleFeature?.Delete ?? false,
                    Report = roleFeature?.Report ?? false,
                };
            }).OrderBy(x => x.FeatureKey).ToList();

            return result;

        }
    }
}
