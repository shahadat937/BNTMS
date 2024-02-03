using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using SchoolManagement.Application.Features.Events.Requests.Commands;

namespace SchoolManagement.Application.Features.Events.Handlers.Commands
{
    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var Event = await _unitOfWork.Repository<Event>().Get(request.EventId);

            if (Event == null)
                throw new NotFoundException(nameof(Event), request.EventId);

            await _unitOfWork.Repository<Event>().Delete(Event);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
