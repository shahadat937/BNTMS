using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamCenterSelections.Requests.Commands;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamCenterSelections.Handlers.Commands
{
    public class DeleteExamCenterSelectionCommandHandler : IRequestHandler<DeleteExamCenterSelectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExamCenterSelectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExamCenterSelectionCommand request, CancellationToken cancellationToken)
        {
            var ExamCenterSelection = await _unitOfWork.Repository<ExamCenterSelection>().Get(request.ExamCenterSelectionId);

            if (ExamCenterSelection == null)
                throw new NotFoundException(nameof(ExamCenterSelection), request.ExamCenterSelectionId);

            await _unitOfWork.Repository<ExamCenterSelection>().Delete(ExamCenterSelection);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
