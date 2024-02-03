using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamAttemptTypes.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamAttemptTypes.Handlers.Commands
{
    public class DeleteExamAttemptTypeCommandHandler : IRequestHandler<DeleteExamAttemptTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExamAttemptTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExamAttemptTypeCommand request, CancellationToken cancellationToken)
        {
            var ExamAttemptType = await _unitOfWork.Repository<ExamAttemptType>().Get(request.ExamAttemptTypeId);

            if (ExamAttemptType == null)
                throw new NotFoundException(nameof(ExamAttemptType), request.ExamAttemptTypeId);

            await _unitOfWork.Repository<ExamAttemptType>().Delete(ExamAttemptType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
