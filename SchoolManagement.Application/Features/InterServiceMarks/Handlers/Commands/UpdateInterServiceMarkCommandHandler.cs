using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.InterServiceMark.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.InterServiceMarks.Requests.Commands;

namespace SchoolManagement.Application.Features.InterServiceMarks.Handlers.Commands
{
    public class UpdateInterServiceMarkCommandHandler : IRequestHandler<UpdateInterServiceMarkCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateInterServiceMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateInterServiceMarkCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateInterServiceMarkDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.InterServiceMarkDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var InterServiceMark = await _unitOfWork.Repository<InterServiceMark>().Get(request.InterServiceMarkDto.InterServiceMarkId);

            if (InterServiceMark is null)
                throw new NotFoundException(nameof(InterServiceMark), request.InterServiceMarkDto.InterServiceMarkId);

            _mapper.Map(request.InterServiceMarkDto, InterServiceMark);

            await _unitOfWork.Repository<InterServiceMark>().Update(InterServiceMark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
