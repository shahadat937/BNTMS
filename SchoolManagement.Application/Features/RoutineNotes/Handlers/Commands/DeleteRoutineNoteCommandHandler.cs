using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Commands
{
    public class DeleteRoutineNoteCommandHandler : IRequestHandler<DeleteRoutineNoteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRoutineNoteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRoutineNoteCommand request, CancellationToken cancellationToken)
        {
            var RoutineNote = await _unitOfWork.Repository<RoutineNote>().Get(request.RoutineNoteId);

            if (RoutineNote == null)
                throw new NotFoundException(nameof(RoutineNote), request.RoutineNoteId);

            await _unitOfWork.Repository<RoutineNote>().Delete(RoutineNote);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
