using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Elections.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Elections.Handlers.Commands
{
    public class DeleteElectionCommandHandler : IRequestHandler<DeleteElectionCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteElectionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteElectionCommand request, CancellationToken cancellationToken)
        {
            var Election = await _unitOfWork.Repository<Election>().Get(request.ElectionId);

            if (Election == null)
                throw new NotFoundException(nameof(Election), request.ElectionId);

            await _unitOfWork.Repository<Election>().Delete(Election);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
