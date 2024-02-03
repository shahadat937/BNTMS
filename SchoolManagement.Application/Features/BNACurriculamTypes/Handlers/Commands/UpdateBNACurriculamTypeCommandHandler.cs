using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.BnaCurriculamType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Handlers.Commands
{
    public class UpdateBnaCurriculamTypeCommandHandler : IRequestHandler<UpdateBnaCurriculamTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBnaCurriculamTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBnaCurriculamTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBnaCurriculamTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.BnaCurriculamTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var BnaCurriculamType = await _unitOfWork.Repository<BnaCurriculumType>().Get(request.BnaCurriculamTypeDto.BnaCurriculumTypeId);

            if (BnaCurriculamType is null)
                throw new NotFoundException(nameof(BnaCurriculamType), request.BnaCurriculamTypeDto.BnaCurriculumTypeId);

            _mapper.Map(request.BnaCurriculamTypeDto, BnaCurriculamType);

            await _unitOfWork.Repository<BnaCurriculumType>().Update(BnaCurriculamType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
