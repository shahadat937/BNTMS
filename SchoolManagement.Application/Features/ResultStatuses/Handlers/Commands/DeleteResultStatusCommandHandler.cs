using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ResultStatuses.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ResultStatuses.Handlers.Commands
{
    public class DeleteResultStatusCommandHandler : IRequestHandler<DeleteResultStatusCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteResultStatusCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteResultStatusCommand request, CancellationToken cancellationToken)
        {
            var ResultStatus = await _unitOfWork.Repository<ResultStatus>().Get(request.ResultStatusId);

            if (ResultStatus == null)
                throw new NotFoundException(nameof(ResultStatus), request.ResultStatusId);

            await _unitOfWork.Repository<ResultStatus>().Delete(ResultStatus);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
