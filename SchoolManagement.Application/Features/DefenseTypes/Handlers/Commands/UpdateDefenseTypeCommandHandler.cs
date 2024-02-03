using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DefenseType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DefenseTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DefenseTypes.Handlers.Commands
{
    public class UpdateDefenseTypeCommandHandler : IRequestHandler<UpdateDefenseTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDefenseTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDefenseTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDefenseTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DefenseTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DefenseType = await _unitOfWork.Repository<DefenseType>().Get(request.DefenseTypeDto.DefenseTypeId);

            if (DefenseType is null)
                throw new NotFoundException(nameof(DefenseType), request.DefenseTypeDto.DefenseTypeId);

            _mapper.Map(request.DefenseTypeDto, DefenseType);

            await _unitOfWork.Repository<DefenseType>().Update(DefenseType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
