using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.ClassType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassTypes.Handlers.Commands
{
    public class UpdateClassTypeCommandHandler : IRequestHandler<UpdateClassTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateClassTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateClassTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateClassTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.ClassTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var ClassType = await _unitOfWork.Repository<ClassType>().Get(request.ClassTypeDto.ClassTypeId);

            if (ClassType is null)
                throw new NotFoundException(nameof(ClassType), request.ClassTypeDto.ClassTypeId);

            _mapper.Map(request.ClassTypeDto, ClassType);

            await _unitOfWork.Repository<ClassType>().Update(ClassType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
