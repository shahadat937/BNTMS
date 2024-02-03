using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UtofficerTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerTypes.Handlers.Commands
{
    public class DeleteUtofficerTypeCommandHandler : IRequestHandler<DeleteUtofficerTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUtofficerTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUtofficerTypeCommand request, CancellationToken cancellationToken)
        {
            var UtofficerType = await _unitOfWork.Repository<UtofficerType>().Get(request.UtofficerTypeId);

            if (UtofficerType == null)
                throw new NotFoundException(nameof(UtofficerType), request.UtofficerTypeId);

            await _unitOfWork.Repository<UtofficerType>().Delete(UtofficerType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
