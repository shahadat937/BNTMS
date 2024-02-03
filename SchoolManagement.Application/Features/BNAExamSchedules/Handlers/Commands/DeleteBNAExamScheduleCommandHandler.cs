using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamSchedules.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamSchedules.Handlers.Commands
{
    public class DeleteBnaExamScheduleCommandHandler : IRequestHandler<DeleteBnaExamScheduleCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaExamScheduleCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaExamScheduleCommand request, CancellationToken cancellationToken)
        {
            var BnaExamSchedule = await _unitOfWork.Repository<BnaExamSchedule>().Get(request.BnaExamScheduleId);

            if (BnaExamSchedule == null)
                throw new NotFoundException(nameof(BnaExamSchedule), request.BnaExamScheduleId);

            await _unitOfWork.Repository<BnaExamSchedule>().Delete(BnaExamSchedule);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
