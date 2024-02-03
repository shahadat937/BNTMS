using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Favorite.Requests.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Favorite.Handlers.Commands
{
    public class DeleteFavoritesCommandHandler : IRequestHandler<DeleteFavoritesCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteFavoritesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteFavoritesCommand request, CancellationToken cancellationToken)
        {  
            var Favorites = await _unitOfWork.Repository<Favorites>().Get(request.Id);

            if (Favorites == null)  
                throw new NotFoundException(nameof(Favorites), request.Id);
             
            await _unitOfWork.Repository<Favorites>().Delete(Favorites); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}