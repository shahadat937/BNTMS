using AutoMapper;
using SchoolManagement.Application.DTOs.TraineePicture.Validators;
using SchoolManagement.Application.Features.TraineePictures.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;

namespace SchoolManagement.Application.Features.TraineePictures.Handlers.Commands
{
    public class CreateTraineePictureCommandHandler : IRequestHandler<CreateTraineePictureCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineePictureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineePictureCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineePictureDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineePictureDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineePictures = _mapper.Map<TraineePicture>(request.TraineePictureDto);

                TraineePictures = await _unitOfWork.Repository<TraineePicture>().Add(TraineePictures);
                
                
                    await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineePictures.TraineePictureId;
            }

            return response;
        }
    }
}
