using AutoMapper;
using SchoolManagement.Application.DTOs.Election.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Elections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Elections.Handlers.Commands
{
    public class UpdateElectionCommandHandler : IRequestHandler<UpdateElectionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateElectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateElectionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateElectionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ElectionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Election = await _unitOfWork.Repository<Election>().Get(request.ElectionDto.ElectionId);

            if (Election is null)
                throw new NotFoundException(nameof(Election), request.ElectionDto.ElectionId);

            _mapper.Map(request.ElectionDto, Election);

            await _unitOfWork.Repository<Election>().Update(Election);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
