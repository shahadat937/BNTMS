using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FailureStatuses.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FailureStatuses.Handlers.Commands
{
    public class DeleteFailureStatusCommandHandler : IRequestHandler<DeleteFailureStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFailureStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFailureStatusCommand request, CancellationToken cancellationToken)
        {
            var FailureStatus = await _unitOfWork.Repository<FailureStatus>().Get(request.FailureStatusId);

            if (FailureStatus == null)
                throw new NotFoundException(nameof(FailureStatus), request.FailureStatusId);

            await _unitOfWork.Repository<FailureStatus>().Delete(FailureStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
