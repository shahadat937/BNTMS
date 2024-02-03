using AutoMapper;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Favorite.Validators;
using SchoolManagement.Application.Features.Favorite.Requests.Commands;
using SchoolManagement.Application.Responses;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Favorite.Handlers.Commands
{
    public class CreateFavoritesCommandHandler : IRequestHandler<CreateFavoritesCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateFavoritesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateFavoritesCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFavoritesDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.FavoritesDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Favorites = _mapper.Map<Favorites>(request.FavoritesDto); 

                Favorites = await _unitOfWork.Repository<Favorites>().Add(Favorites);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = Favorites.FavoritesId;
            }

            return response;
        }
    }
}
