﻿using AutoMapper;
using SchoolManagement.Application.DTOs.Religion.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Religions.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Religions.Handlers.Commands
{
    public class UpdateReligionCommandHandler : IRequestHandler<UpdateReligionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateReligionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateReligionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateReligionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ReligionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Religion = await _unitOfWork.Repository<Religion>().Get(request.ReligionDto.ReligionId);

            if (Religion is null)
                throw new NotFoundException(nameof(Religion), request.ReligionDto.ReligionId);

            _mapper.Map(request.ReligionDto, Religion);

            await _unitOfWork.Repository<Religion>().Update(Religion);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
