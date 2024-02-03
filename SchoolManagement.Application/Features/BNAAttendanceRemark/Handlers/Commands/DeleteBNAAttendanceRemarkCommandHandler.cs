using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaAttendanceRemark.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaAttendanceRemark.Handlers.Commands
{
    public class DeleteBnaAttendanceRemarkCommandHandler : IRequestHandler<DeleteBnaAttendanceRemarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaAttendanceRemarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaAttendanceRemarkCommand request, CancellationToken cancellationToken)
        {
            var BnaAttendanceRemark = await _unitOfWork.Repository<BnaAttendanceRemarks>().Get(request.BnaAttendanceRemarksId);

            if (BnaAttendanceRemark == null)
                throw new NotFoundException(nameof(BnaAttendanceRemark), request.BnaAttendanceRemarksId);

            await _unitOfWork.Repository<BnaAttendanceRemarks>().Delete(BnaAttendanceRemark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
