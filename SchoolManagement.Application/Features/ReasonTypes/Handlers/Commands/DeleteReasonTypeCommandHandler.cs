using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ReasonTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReasonTypes.Handlers.Commands
{
    public class DeleteReasonTypeCommandHandler : IRequestHandler<DeleteReasonTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteReasonTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteReasonTypeCommand request, CancellationToken cancellationToken)
        {
            var ReasonType = await _unitOfWork.Repository<ReasonType>().Get(request.ReasonTypeId);

            if (ReasonType == null)
                throw new NotFoundException(nameof(ReasonType), request.ReasonTypeId);

            await _unitOfWork.Repository<ReasonType>().Delete(ReasonType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
