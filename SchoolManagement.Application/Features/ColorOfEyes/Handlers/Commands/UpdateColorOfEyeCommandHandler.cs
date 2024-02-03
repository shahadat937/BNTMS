using AutoMapper;
using SchoolManagement.Application.DTOs.ColorOfEye.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ColorOfEyes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace SchoolManagement.Application.Features.ColorOfEyes.Handlers.Commands
{
    public class UpdateColorOfEyeCommandHandler : IRequestHandler<UpdateColorOfEyeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateColorOfEyeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateColorOfEyeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateColorOfEyeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ColorOfEyeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ColorOfEye = await _unitOfWork.Repository<ColorOfEye>().Get(request.ColorOfEyeDto.ColorOfEyeId);

            if (ColorOfEye is null)
                throw new NotFoundException(nameof(ColorOfEye), request.ColorOfEyeDto.ColorOfEyeId);

            _mapper.Map(request.ColorOfEyeDto, ColorOfEye);

            await _unitOfWork.Repository<ColorOfEye>().Update(ColorOfEye);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
