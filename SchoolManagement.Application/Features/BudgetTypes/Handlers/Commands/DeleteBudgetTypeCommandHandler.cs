using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BudgetTypes.Handlers.Commands
{
    public class DeleteBudgetTypeCommandHandler : IRequestHandler<DeleteBudgetTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBudgetTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBudgetTypeCommand request, CancellationToken cancellationToken)
        {
            var BudgetType = await _unitOfWork.Repository<BudgetType>().Get(request.BudgetTypeId);

            if (BudgetType == null)
                throw new NotFoundException(nameof(BudgetType), request.BudgetTypeId);

            await _unitOfWork.Repository<BudgetType>().Delete(BudgetType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
