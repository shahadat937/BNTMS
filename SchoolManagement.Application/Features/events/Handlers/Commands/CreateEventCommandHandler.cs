using AutoMapper;
using SchoolManagement.Application.DTOs.Event.Validators;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Features.Events.Requests.Commands;

namespace SchoolManagement.Application.Features.Events.Handlers.Commands
{
    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEventCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEventDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EventDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Event = _mapper.Map<Event>(request.EventDto);

                Event = await _unitOfWork.Repository<Event>().Add(Event);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = Event.EventId;
            }

            return response;
        }
    }
}
