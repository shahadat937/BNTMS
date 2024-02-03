using AutoMapper;
using SchoolManagement.Application.DTOs.CoCurricularActivityType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CoCurricularActivityTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CoCurricularActivityTypes.Handlers.Commands
{
    public class UpdateCoCurricularActivityTypeCommandHandler : IRequestHandler<UpdateCoCurricularActivityTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCoCurricularActivityTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCoCurricularActivityTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateCoCurricularActivityTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CoCurricularActivityTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var CoCurricularActivityType = await _unitOfWork.Repository<CoCurricularActivityType>().Get(request.CoCurricularActivityTypeDto.CoCurricularActivityTypeId);

            if (CoCurricularActivityType is null)
                throw new NotFoundException(nameof(CoCurricularActivityType), request.CoCurricularActivityTypeDto.CoCurricularActivityTypeId);

            _mapper.Map(request.CoCurricularActivityTypeDto, CoCurricularActivityType);

            await _unitOfWork.Repository<CoCurricularActivityType>().Update(CoCurricularActivityType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
