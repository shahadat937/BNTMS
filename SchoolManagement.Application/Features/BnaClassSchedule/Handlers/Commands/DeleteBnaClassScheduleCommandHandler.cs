using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaClassSchedules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassSchedules.Handlers.Commands
{
    public class DeleteBnaClassScheduleCommandHandler : IRequestHandler<DeleteBnaClassScheduleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaClassScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaClassScheduleCommand request, CancellationToken cancellationToken)
        {
            var BnaClassSchedules = await _unitOfWork.Repository<BnaClassSchedule>().Get(request.BnaClassScheduleId);

            if (BnaClassSchedules == null)
                throw new NotFoundException(nameof(BnaClassSchedule), request.BnaClassScheduleId);

            await _unitOfWork.Repository<BnaClassSchedule>().Delete(BnaClassSchedules);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
