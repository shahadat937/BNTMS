using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BudgetTransactionType.Handler.Command
{
    //public class DeleteBudgetTransactionCommandHandler : IRequestHandler<DeleteBudgetTransactionCommandHandler>
    //{
    //    private readonly IUnitOfWork _unitOfWork;
    //    private readonly IMapper _mapper;

    //    public DeleteBudgetTransactionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    //    {
    //        _unitOfWork = unitOfWork;
    //        _mapper = mapper;
    //    }

    //    public async Task<Unit> Handle(DeleteBudgetTransactionCommandHandler requesr, CancellationToken cancellationToken)
    //    {
    //        var BudgetTransaction = await _unitOfWork.Repository<BudgetTransaction>().Get(request.BudgetTransactionId);
    //    }

    //}
}
