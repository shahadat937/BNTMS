using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineePictures.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineePictures.Handlers.Commands
{
    public class DeleteTraineePictureCommandHandler : IRequestHandler<DeleteTraineePictureCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineePictureCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineePictureCommand request, CancellationToken cancellationToken)
        {
            var TraineePictures = await _unitOfWork.Repository<TraineePicture>().Get(request.TraineePictureId);

            if (TraineePictures == null)
                throw new NotFoundException(nameof(TraineePicture), request.TraineePictureId);

            await _unitOfWork.Repository<TraineePicture>().Delete(TraineePictures);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
