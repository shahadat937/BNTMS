using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaServiceTypes.Handlers.Commands
{
    public class DeleteBnaServiceTypeCommandHandler : IRequestHandler<DeleteBnaServiceTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaServiceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var BnaServiceType = await _unitOfWork.Repository<BnaServiceType>().Get(request.BnaServiceTypeId);

            if (BnaServiceType == null)
                throw new NotFoundException(nameof(BnaServiceType), request.BnaServiceTypeId);

            await _unitOfWork.Repository<BnaServiceType>().Delete(BnaServiceType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
 