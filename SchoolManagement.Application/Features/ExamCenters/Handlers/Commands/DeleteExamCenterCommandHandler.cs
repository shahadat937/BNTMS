using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamCenters.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamCenters.Handlers.Commands
{
    public class DeleteExamCenterCommandHandler : IRequestHandler<DeleteExamCenterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExamCenterCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExamCenterCommand request, CancellationToken cancellationToken)
        {
            var ExamCenter = await _unitOfWork.Repository<ExamCenter>().Get(request.ExamCenterId);

            if (ExamCenter == null)
                throw new NotFoundException(nameof(ExamCenter), request.ExamCenterId);

            await _unitOfWork.Repository<ExamCenter>().Delete(ExamCenter);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
