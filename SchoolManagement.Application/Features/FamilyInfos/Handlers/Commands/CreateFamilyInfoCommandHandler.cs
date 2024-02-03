using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FamilyInfo.Validators;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Commands
{
    public class CreateFamilyInfoCommandHandler : IRequestHandler<CreateFamilyInfoCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFamilyInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFamilyInfoCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFamilyInfoDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FamilyInfoDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FamilyInfo = _mapper.Map<FamilyInfo>(request.FamilyInfoDto);

                FamilyInfo = await _unitOfWork.Repository<FamilyInfo>().Add(FamilyInfo);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FamilyInfo.FamilyInfoId;
            }

            return response;
        }
    }
}
