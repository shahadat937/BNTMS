using AutoMapper;
using SchoolManagement.Application.DTOs.GameSport.Validators;
using SchoolManagement.Application.Features.GameSports.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.GameSports.Handlers.Commands
{
    public class CreateGameSportCommandHandler : IRequestHandler<CreateGameSportCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGameSportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGameSportCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateGameSportDtoValidator();
            var validationResult = await validator.ValidateAsync(request.GameSportDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var GameSport = _mapper.Map<GameSport>(request.GameSportDto);

                GameSport = await _unitOfWork.Repository<GameSport>().Add(GameSport);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = GameSport.GameSportId;
            }

            return response;
        }
    }
}
