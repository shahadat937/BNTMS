using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Commands;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BudgetCodess.Handlers.Commands
{
    public class DeleteBudgetCodeCommandHandler : IRequestHandler<DeleteBudgetCodeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBudgetCodeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBudgetCodeCommand request, CancellationToken cancellationToken)
        {
            var BudgetCode = await _unitOfWork.Repository<BudgetCode>().Get(request.BudgetCodeId);

            if (BudgetCode == null)
                throw new NotFoundException(nameof(BudgetCode), request.BudgetCodeId);

            await _unitOfWork.Repository<BudgetCode>().Delete(BudgetCode);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
