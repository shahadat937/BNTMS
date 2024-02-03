using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.FavoritesType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FavoritesTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FavoritesTypes.Handlers.Commands
{
    public class UpdateFavoritesTypeCommandHandler : IRequestHandler<UpdateFavoritesTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateFavoritesTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateFavoritesTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateFavoritesTypeDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.FavoritesTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var FavoritesType = await _unitOfWork.Repository<FavoritesType>().Get(request.FavoritesTypeDto.FavoritesTypeId);

            if (FavoritesType is null)
                throw new NotFoundException(nameof(FavoritesType), request.FavoritesTypeDto.FavoritesTypeId);

            _mapper.Map(request.FavoritesTypeDto, FavoritesType);

            await _unitOfWork.Repository<FavoritesType>().Update(FavoritesType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
