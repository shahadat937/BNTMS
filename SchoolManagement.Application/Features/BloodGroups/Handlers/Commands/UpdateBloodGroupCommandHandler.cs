﻿using AutoMapper;
using SchoolManagement.Application.DTOs.BloodGroup.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BloodGroups.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BloodGroups.Handlers.Commands
{
    public class UpdateBloodGroupCommandHandler : IRequestHandler<UpdateBloodGroupCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBloodGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBloodGroupCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBloodGroupDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BloodGroupDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BloodGroup = await _unitOfWork.Repository<BloodGroup>().Get(request.BloodGroupDto.BloodGroupId);

            if (BloodGroup is null)
                throw new NotFoundException(nameof(BloodGroup), request.BloodGroupDto.BloodGroupId);

            _mapper.Map(request.BloodGroupDto, BloodGroup);

            await _unitOfWork.Repository<BloodGroup>().Update(BloodGroup);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
