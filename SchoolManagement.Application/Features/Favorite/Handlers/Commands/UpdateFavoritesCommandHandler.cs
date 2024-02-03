using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Favorites.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Favorite.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Favorite.Handlers.Commands
{
    public class UpdateFavoritesCommandHandler : IRequestHandler<UpdateFavoritesCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateFavoritesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateFavoritesCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFavoritesDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.FavoritesDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var Favorites = await _unitOfWork.Repository<Favorites>().Get(request.FavoritesDto.FavoritesId); 

            if (Favorites is null)  
                throw new NotFoundException(nameof(Favorites), request.FavoritesDto.FavoritesId); 

            _mapper.Map(request.FavoritesDto, Favorites);  

            await _unitOfWork.Repository<Favorites>().Update(Favorites); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}