using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TdecActionStatuses.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecActionStatuses.Handlers.Commands
{
    public class DeleteTdecActionStatusCommandHandler : IRequestHandler<DeleteTdecActionStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTdecActionStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTdecActionStatusCommand request, CancellationToken cancellationToken)
        {
            var TdecActionStatus = await _unitOfWork.Repository<TdecActionStatus>().Get(request.TdecActionStatusId);

            if (TdecActionStatus == null)
                throw new NotFoundException(nameof(TdecActionStatus), request.TdecActionStatusId);

            await _unitOfWork.Repository<TdecActionStatus>().Delete(TdecActionStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
