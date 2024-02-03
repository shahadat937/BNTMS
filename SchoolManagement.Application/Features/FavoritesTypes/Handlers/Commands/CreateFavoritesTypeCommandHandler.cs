using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FavoritesType.Validators;
using SchoolManagement.Application.Features.FavoritesTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FavoritesTypes.Handlers.Commands
{
    public class CreateFavoritesTypeCommandHandler : IRequestHandler<CreateFavoritesTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateFavoritesTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateFavoritesTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateFavoritesTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.FavoritesTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var FavoritesType = _mapper.Map<FavoritesType>(request.FavoritesTypeDto);

                FavoritesType = await _unitOfWork.Repository<FavoritesType>().Add(FavoritesType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = FavoritesType.FavoritesTypeId;
            }

            return response;
        }
    }
}
