using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Events.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.Events.Handlers.Commands
{
    public class ChangeEventStatusCommandHandler : IRequestHandler<ChangeEventStatusCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public ChangeEventStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(ChangeEventStatusCommand request, CancellationToken cancellationToken)
        {
            var Event = await _unitOfWork.Repository<Event>().Get(request.EventId);
            Event.Status = request.Status;

            if (Event == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            await _unitOfWork.Repository<Event>().Update(Event);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
