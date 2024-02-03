using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassScheduleStatuss.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassScheduleStatuss.Handlers.Commands
{
    public class DeleteBnaClassScheduleStatusCommandHandler : IRequestHandler<DeleteBnaClassScheduleStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaClassScheduleStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaClassScheduleStatusCommand request, CancellationToken cancellationToken)
        {
            var BnaClassScheduleStatus = await _unitOfWork.Repository<BnaClassScheduleStatus>().Get(request.BnaClassScheduleStatusId);

            if (BnaClassScheduleStatus == null)
                throw new NotFoundException(nameof(BnaClassScheduleStatus), request.BnaClassScheduleStatusId);

            await _unitOfWork.Repository<BnaClassScheduleStatus>().Delete(BnaClassScheduleStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
