using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.NewAtempt.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.NewAtempts.Requests.Commands;

namespace SchoolManagement.Application.Features.NewAtempts.Handlers.Commands
{
    public class UpdateNewAtemptCommandHandler : IRequestHandler<UpdateNewAtemptCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateNewAtemptCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateNewAtemptCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateNewAtemptDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.NewAtemptDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var NewAtempt = await _unitOfWork.Repository<NewAtempt>().Get(request.NewAtemptDto.NewAtemptId);

            if (NewAtempt is null)
                throw new NotFoundException(nameof(NewAtempt), request.NewAtemptDto.NewAtemptId);

            _mapper.Map(request.NewAtemptDto, NewAtempt);

            await _unitOfWork.Repository<NewAtempt>().Update(NewAtempt);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
