using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.RoutineSoftCopyUploads.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RoutineSoftCopyUploads.Handlers.Commands
{
    public class DeleteRoutineSoftCopyUploadCommandHandler : IRequestHandler<DeleteRoutineSoftCopyUploadCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteRoutineSoftCopyUploadCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteRoutineSoftCopyUploadCommand request, CancellationToken cancellationToken)
        {
            var RoutineSoftCopyUploads = await _unitOfWork.Repository<RoutineSoftCopyUpload>().Get(request.RoutineSoftCopyUploadId);

            if (RoutineSoftCopyUploads == null)
                throw new NotFoundException(nameof(RoutineSoftCopyUpload), request.RoutineSoftCopyUploadId);

            await _unitOfWork.Repository<RoutineSoftCopyUpload>().Delete(RoutineSoftCopyUploads);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
