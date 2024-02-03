using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.FamilyInfo.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.FamilyInfos.Requests.Commands;

namespace SchoolManagement.Application.Features.FamilyInfos.Handlers.Commands
{
    public class UpdateFamilyInfoCommandHandler : IRequestHandler<UpdateFamilyInfoCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFamilyInfoCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFamilyInfoCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFamilyInfoDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.FamilyInfoDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FamilyInfo = await _unitOfWork.Repository<FamilyInfo>().Get(request.FamilyInfoDto.FamilyInfoId);

            if (FamilyInfo is null)
                throw new NotFoundException(nameof(FamilyInfo), request.FamilyInfoDto.FamilyInfoId);

            _mapper.Map(request.FamilyInfoDto, FamilyInfo);

            await _unitOfWork.Repository<FamilyInfo>().Update(FamilyInfo);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
