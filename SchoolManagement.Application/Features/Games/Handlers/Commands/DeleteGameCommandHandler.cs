using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Games.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Games.Handlers.Commands
{
    public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteGameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteGameCommand request, CancellationToken cancellationToken)
        {  
            var Game = await _unitOfWork.Repository<Game>().Get(request.Id);

            if (Game == null)  
                throw new NotFoundException(nameof(Game), request.Id);
             
            await _unitOfWork.Repository<Game>().Delete(Game); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}