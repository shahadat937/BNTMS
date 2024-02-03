using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Games.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Games.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Games.Handlers.Commands
{
    public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateGameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateGameCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGameDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.GameDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var Game = await _unitOfWork.Repository<Game>().Get(request.GameDto.GameId); 

            if (Game is null)  
                throw new NotFoundException(nameof(Game), request.GameDto.GameId); 

            _mapper.Map(request.GameDto, Game);  

            await _unitOfWork.Repository<Game>().Update(Game); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}