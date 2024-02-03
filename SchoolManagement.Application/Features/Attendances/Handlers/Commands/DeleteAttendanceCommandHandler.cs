using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Attendances.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Attendances.Handlers.Commands
{
    public class DeleteAttendanceCommandHandler : IRequestHandler<DeleteAttendanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAttendanceCommand request, CancellationToken cancellationToken)
        {
            var Attendances = await _unitOfWork.Repository<Attendance>().Get(request.AttendanceId);

            if (Attendances == null)
                throw new NotFoundException(nameof(Attendance), request.AttendanceId);

            await _unitOfWork.Repository<Attendance>().Delete(Attendances);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
