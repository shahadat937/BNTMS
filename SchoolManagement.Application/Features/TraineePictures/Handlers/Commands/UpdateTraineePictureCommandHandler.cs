using AutoMapper;
using SchoolManagement.Application.DTOs.TraineePicture.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineePictures.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineePictures.Handlers.Commands
{
    public class UpdateTraineePictureCommandHandler : IRequestHandler<UpdateTraineePictureCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTraineePictureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateTraineePictureCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineePictureDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineePictureDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var TraineePictures = await _unitOfWork.Repository<TraineePicture>().Get(request.TraineePictureDto.TraineePictureId);

            if (TraineePictures is null)
                throw new NotFoundException(nameof(TraineePicture), request.TraineePictureDto.TraineePictureId);

            _mapper.Map(request.TraineePictureDto, TraineePictures);

            await _unitOfWork.Repository<TraineePicture>().Update(TraineePictures);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
