using AutoMapper;
using SchoolManagement.Application.DTOs.FailureStatus.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FailureStatuses.Handlers.Commands
{
    public class UpdateFailureStatusCommandHandler : IRequestHandler<UpdateFailureStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFailureStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFailureStatusCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFailureStatusDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FailureStatusDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FailureStatus = await _unitOfWork.Repository<FailureStatus>().Get(request.FailureStatusDto.FailureStatusId);

            if (FailureStatus is null)
                throw new NotFoundException(nameof(FailureStatus), request.FailureStatusDto.FailureStatusId);

            _mapper.Map(request.FailureStatusDto, FailureStatus);

            await _unitOfWork.Repository<FailureStatus>().Update(FailureStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
