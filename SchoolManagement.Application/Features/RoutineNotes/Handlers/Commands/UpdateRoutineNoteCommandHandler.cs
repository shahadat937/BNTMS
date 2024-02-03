using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Commands;
using SchoolManagement.Application.DTOs.RoutineNote.Validators;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Commands
{
    public class UpdateRoutineNoteCommandHandler : IRequestHandler<UpdateRoutineNoteCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateRoutineNoteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateRoutineNoteCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRoutineNoteDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.RoutineNoteDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var RoutineNote = await _unitOfWork.Repository<RoutineNote>().Get(request.RoutineNoteDto.RoutineNoteId);

            if (RoutineNote is null)
                throw new NotFoundException(nameof(RoutineNote), request.RoutineNoteDto.RoutineNoteId);

            _mapper.Map(request.RoutineNoteDto, RoutineNote);

            await _unitOfWork.Repository<RoutineNote>().Update(RoutineNote);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
