using AutoMapper;
using SchoolManagement.Application.DTOs.SwimmingDriving.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Handlers.Commands
{
    public class UpdateSwimmingDrivingCommandHandler : IRequestHandler<UpdateSwimmingDrivingCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSwimmingDrivingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateSwimmingDrivingCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSwimmingDrivingDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SwimmingDrivingDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var SwimmingDrivings = await _unitOfWork.Repository<SwimmingDriving>().Get(request.SwimmingDrivingDto.SwimmingDrivingId);

            if (SwimmingDrivings is null)
                throw new NotFoundException(nameof(SwimmingDriving), request.SwimmingDrivingDto.SwimmingDrivingId);

            _mapper.Map(request.SwimmingDrivingDto, SwimmingDrivings);

            await _unitOfWork.Repository<SwimmingDriving>().Update(SwimmingDrivings);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
