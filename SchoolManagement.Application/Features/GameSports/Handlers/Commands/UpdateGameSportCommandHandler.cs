using AutoMapper;
using SchoolManagement.Application.DTOs.GameSport.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GameSports.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GameSports.Handlers.Commands
{
    public class UpdateGameSportCommandHandler : IRequestHandler<UpdateGameSportCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateGameSportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateGameSportCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateGameSportDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GameSportDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var GameSport = await _unitOfWork.Repository<GameSport>().Get(request.GameSportDto.GameSportId);

            if (GameSport is null)
                throw new NotFoundException(nameof(GameSport), request.GameSportDto.GameSportId);

            _mapper.Map(request.GameSportDto, GameSport);

            await _unitOfWork.Repository<GameSport>().Update(GameSport);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
