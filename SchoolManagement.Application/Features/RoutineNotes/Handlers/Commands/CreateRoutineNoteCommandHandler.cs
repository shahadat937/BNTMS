using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RoutineNote.Validators;
using SchoolManagement.Application.Features.RoutineNotes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.RoutineNotes.Handlers.Commands
{
    public class CreateRoutineNoteCommandHandler : IRequestHandler<CreateRoutineNoteCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateRoutineNoteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateRoutineNoteCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateRoutineNoteDtoValidator();
            var validationResult = await validator.ValidateAsync(request.RoutineNoteDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var RoutineNote = _mapper.Map<RoutineNote>(request.RoutineNoteDto);

                try
                {
                    RoutineNote = await _unitOfWork.Repository<RoutineNote>().Add(RoutineNote);
                    await _unitOfWork.Save();
                }catch(Exception e)
                {
                    Console.WriteLine(e);
                }
                


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = RoutineNote.RoutineNoteId;
            }

            return response;
        }
    }
}
