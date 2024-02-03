using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaExamAttendances.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BnaExamAttendances.Handlers.Commands
{
    public class DeleteBnaExamAttendanceCommandHandler : IRequestHandler<DeleteBnaExamAttendanceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaExamAttendanceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaExamAttendanceCommand request, CancellationToken cancellationToken)
        {
            var BnaExamAttendances = await _unitOfWork.Repository<BnaExamAttendance>().Get(request.BnaExamAttendanceId);

            if (BnaExamAttendances == null)
                throw new NotFoundException(nameof(BnaExamAttendance), request.BnaExamAttendanceId);

            await _unitOfWork.Repository<BnaExamAttendance>().Delete(BnaExamAttendances);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
