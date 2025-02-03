using AutoMapper;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.FamilyInfo;
using SchoolManagement.Application.Features.FamilyInfos.Requests;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using SchoolManagement.Application.Models;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Queries
{
    public class GetFamilyInfoListTraineeIdRequestHandler : IRequestHandler<GetFamilyInfoListTraineeIdRequest, List<FamilyInfoDto>>
    {
         
        private readonly ISchoolManagementRepository<FamilyInfo> _FamilyInfoRepository;
        private readonly ISchoolManagementRepository<FamilyNomination> _FamilyNomination;

        private readonly IMapper _mapper;

        public GetFamilyInfoListTraineeIdRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.FamilyInfo> FamilyInfoRepository, IMapper mapper, ISchoolManagementRepository<FamilyNomination> familyNomination)
        {
            _FamilyInfoRepository = FamilyInfoRepository;
            _mapper = mapper;
            _FamilyNomination = familyNomination;
        }

        public async Task<List<FamilyInfoDto>> Handle(GetFamilyInfoListTraineeIdRequest request, CancellationToken cancellationToken)
        {
            var FamilyInfos = _FamilyInfoRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId, "Trainee", "RelationType", "Trainee.Rank");
            var familyNomination = _FamilyNomination.FilterWithInclude(x => x.TraineeId == request.TraineeId);
            var FamilyInfoDtos = _mapper.Map<List<FamilyInfoDto>>(FamilyInfos);
            foreach (var familyInfoDto in FamilyInfoDtos)
            {
                var nomination = familyNomination.FirstOrDefault(n => n.FamilyInfoId == familyInfoDto.FamilyInfoId);
                if (nomination != null)
                {
                    familyInfoDto.Status = nomination.Status;
                    familyInfoDto.FamilyNominationId = nomination.FamilyNominationId;
                }
            }

            return FamilyInfoDtos;

        }
    }
}
