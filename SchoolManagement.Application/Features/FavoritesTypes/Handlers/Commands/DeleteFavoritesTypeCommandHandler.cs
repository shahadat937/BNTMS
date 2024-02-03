using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FavoritesTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FavoritesTypes.Handlers.Commands
{
    public class DeleteFavoritesTypeCommandHandler : IRequestHandler<DeleteFavoritesTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFavoritesTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFavoritesTypeCommand request, CancellationToken cancellationToken)
        {
            var FavoritesType = await _unitOfWork.Repository<FavoritesType>().Get(request.FavoritesTypeId);

            if (FavoritesType == null)
                throw new NotFoundException(nameof(FavoritesType), request.FavoritesTypeId);

            await _unitOfWork.Repository<FavoritesType>().Delete(FavoritesType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
