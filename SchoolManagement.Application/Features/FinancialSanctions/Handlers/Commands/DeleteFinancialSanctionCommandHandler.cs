using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.FinancialSanctions.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.FinancialSanctions.Handlers.Commands
{
    public class DeleteFinancialSanctionCommandHandler : IRequestHandler<DeleteFinancialSanctionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteFinancialSanctionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteFinancialSanctionCommand request, CancellationToken cancellationToken)
        {
            var FinancialSanction = await _unitOfWork.Repository<FinancialSanction>().Get(request.FinancialSanctionId);

            if (FinancialSanction == null)
                throw new NotFoundException(nameof(FinancialSanction), request.FinancialSanctionId);

            await _unitOfWork.Repository<FinancialSanction>().Delete(FinancialSanction);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
