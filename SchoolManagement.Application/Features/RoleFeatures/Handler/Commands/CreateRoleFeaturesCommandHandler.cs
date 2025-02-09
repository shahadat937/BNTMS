using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RoleFeatures.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RoleFeatures.Handler.Commands
{
    public class CreateRoleFeaturesCommandHandler : IRequestHandler<CreateRoleFeaturesCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<RoleFeature> _roleFeaturesRepository;

        public CreateRoleFeaturesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ISchoolManagementRepository<RoleFeature> roleFeaturesRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _roleFeaturesRepository = roleFeaturesRepository;
        }
        public async Task<BaseCommandResponse> Handle(CreateRoleFeaturesCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            foreach (var item in request.RoleFeatureDtos)
            {
                if (item.FeatureKey == 0)
                {
                    //var RoleFeaturesInfo = _mapper.Map<RoleFeature>(item);
                    RoleFeature RoleFeaturesInfo = new RoleFeature
                    {
                        RoleId = item.RoleId,
                        FeatureKey = item.FeatureId,
                        Add = item.Add,
                        Update = item.Update,
                        Delete = item.Delete,
                        Report = item.Report,
                    };

                    await _unitOfWork.Repository<RoleFeature>().Add(RoleFeaturesInfo);
                }
                else
                {
                    var RoleFeaturesInfo = await _unitOfWork.Repository<RoleFeature>().FindOneAsync(x=> x.FeatureKey ==  item.FeatureKey && x.RoleId == item.RoleId);

                    if (item.Add == false && item.Update == false && item.Delete == false && item.Report == false)
                    {
                        await _unitOfWork.Repository<RoleFeature>().Delete(RoleFeaturesInfo);
                    }
                    else
                    {

                        RoleFeaturesInfo.RoleId = item.RoleId;
                        RoleFeaturesInfo.FeatureKey = item.FeatureKey;
                        RoleFeaturesInfo.Add = item.Add;
                        RoleFeaturesInfo.Update = item.Update;
                        RoleFeaturesInfo.Delete = item.Delete;
                        RoleFeaturesInfo.Report = item.Report;

                        await _unitOfWork.Repository<RoleFeature>().Update(RoleFeaturesInfo);
                    }

                }
            }

            response.Success = true;
            response.Message = "Update Successful";

            await _unitOfWork.Save();


            return response;
        }
    }
}
