using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SaylorBranchs.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorBranchs.Handlers.Commands
{
    public class DeleteSaylorBranchCommandHandler : IRequestHandler<DeleteSaylorBranchCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSaylorBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSaylorBranchCommand request, CancellationToken cancellationToken)
        {
            var SaylorBranch = await _unitOfWork.Repository<SaylorBranch>().Get(request.SaylorBranchId);

            if (SaylorBranch == null)
                throw new NotFoundException(nameof(SaylorBranch), request.SaylorBranchId);

            await _unitOfWork.Repository<SaylorBranch>().Delete(SaylorBranch);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
