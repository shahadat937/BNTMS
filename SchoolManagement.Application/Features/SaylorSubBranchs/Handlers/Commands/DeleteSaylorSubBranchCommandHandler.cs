using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SaylorSubBranchs.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorSubBranchs.Handlers.Commands
{
    public class DeleteSaylorSubBranchCommandHandler : IRequestHandler<DeleteSaylorSubBranchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSaylorSubBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSaylorSubBranchCommand request, CancellationToken cancellationToken)
        {
            var SaylorSubBranch = await _unitOfWork.Repository<SaylorSubBranch>().Get(request.SaylorSubBranchId);

            if (SaylorSubBranch == null)
                throw new NotFoundException(nameof(SaylorSubBranch), request.SaylorSubBranchId);

            await _unitOfWork.Repository<SaylorSubBranch>().Delete(SaylorSubBranch);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
