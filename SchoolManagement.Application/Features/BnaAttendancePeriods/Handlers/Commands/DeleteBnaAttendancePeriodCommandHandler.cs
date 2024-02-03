using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaAttendancePeriods.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaAttendancePeriods.Handlers.Commands
{
    public class DeleteBnaAttendancePeriodCommandHandler: IRequestHandler<DeleteBnaAttendancePeriodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaAttendancePeriodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaAttendancePeriodCommand request, CancellationToken cancellationToken)
        {
            var BnaAttendancePeriod = await _unitOfWork.Repository<BnaAttendancePeriod>().Get(request.BnaAttendancePeriodId);

            if (BnaAttendancePeriod == null)
                throw new NotFoundException(nameof(BnaAttendancePeriod), request.BnaAttendancePeriodId);

            await _unitOfWork.Repository<BnaAttendancePeriod>().Delete(BnaAttendancePeriod);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
 