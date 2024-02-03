using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Event.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Events.Requests.Commands;

namespace SchoolManagement.Application.Features.Events.Handlers.Commands
{
    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEventDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EventDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Event = await _unitOfWork.Repository<Event>().Get(request.EventDto.EventId);

            if (Event is null)
                throw new NotFoundException(nameof(Event), request.EventDto.EventId);

            _mapper.Map(request.EventDto, Event);

            await _unitOfWork.Repository<Event>().Update(Event);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
