using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.HairColor.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.HairColors.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.HairColors.Handlers.Commands
{
    public class UpdateHairColorCommandHandler : IRequestHandler<UpdateHairColorCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateHairColorCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateHairColorCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateHairColorDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.HairColorDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var HairColor = await _unitOfWork.Repository<HairColor>().Get(request.HairColorDto.HairColorId);

            if (HairColor is null)
                throw new NotFoundException(nameof(HairColor), request.HairColorDto.HairColorId);

            _mapper.Map(request.HairColorDto, HairColor);

            await _unitOfWork.Repository<HairColor>().Update(HairColor);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
