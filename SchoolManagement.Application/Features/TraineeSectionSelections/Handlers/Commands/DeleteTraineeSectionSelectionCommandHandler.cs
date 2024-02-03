using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeSectionSelections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeSectionSelections.Handlers.Commands
{
    public class DeleteTraineeSectionSelectionCommandHandler : IRequestHandler<DeleteTraineeSectionSelectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTraineeSectionSelectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTraineeSectionSelectionCommand request, CancellationToken cancellationToken)
        {
            var TraineeSectionSelections = await _unitOfWork.Repository<TraineeSectionSelection>().Get(request.TraineeSectionSelectionId);

            if (TraineeSectionSelections == null)
                throw new NotFoundException(nameof(TraineeSectionSelection), request.TraineeSectionSelectionId);

            await _unitOfWork.Repository<TraineeSectionSelection>().Delete(TraineeSectionSelections);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
