using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.SaylorRanks.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SaylorRanks.Handlers.Commands
{
    public class DeleteSaylorRankCommandHandler : IRequestHandler<DeleteSaylorRankCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSaylorRankCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteSaylorRankCommand request, CancellationToken cancellationToken)
        {
            var SaylorRank = await _unitOfWork.Repository<SaylorRank>().Get(request.SaylorRankId);

            if (SaylorRank == null)
                throw new NotFoundException(nameof(SaylorRank), request.SaylorRankId);

            await _unitOfWork.Repository<SaylorRank>().Delete(SaylorRank);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
