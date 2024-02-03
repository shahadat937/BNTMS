using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.GameSports.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GameSports.Handlers.Commands
{
    public class DeleteGameSportCommandHandler : IRequestHandler<DeleteGameSportCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteGameSportCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteGameSportCommand request, CancellationToken cancellationToken)
        {
            var GameSport = await _unitOfWork.Repository<GameSport>().Get(request.GameSportId);

            if (GameSport == null)
                throw new NotFoundException(nameof(GameSport), request.GameSportId);

            await _unitOfWork.Repository<GameSport>().Delete(GameSport);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
