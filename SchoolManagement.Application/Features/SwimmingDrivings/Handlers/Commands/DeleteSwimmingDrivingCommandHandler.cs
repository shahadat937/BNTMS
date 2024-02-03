using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SwimmingDrivings.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SwimmingDrivings.Handlers.Commands
{
    public class DeleteSwimmingDrivingCommandHandler : IRequestHandler<DeleteSwimmingDrivingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSwimmingDrivingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSwimmingDrivingCommand request, CancellationToken cancellationToken)
        {
            var SwimmingDrivings = await _unitOfWork.Repository<SwimmingDriving>().Get(request.SwimmingDrivingId);

            if (SwimmingDrivings == null)
                throw new NotFoundException(nameof(SwimmingDriving), request.SwimmingDrivingId);

            await _unitOfWork.Repository<SwimmingDriving>().Delete(SwimmingDrivings);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
