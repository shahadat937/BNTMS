using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.AssignmentMarkEntrys.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AssignmentMarkEntrys.Handlers.Commands
{
    public class DeleteAssignmentMarkEntryCommandHandler : IRequestHandler<DeleteAssignmentMarkEntryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAssignmentMarkEntryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAssignmentMarkEntryCommand request, CancellationToken cancellationToken)
        {
            var AssignmentMarkEntry = await _unitOfWork.Repository<AssignmentMarkEntry>().Get(request.AssignmentMarkEntryId);

            if (AssignmentMarkEntry == null)
                throw new NotFoundException(nameof(AssignmentMarkEntry), request.AssignmentMarkEntryId);

            await _unitOfWork.Repository<AssignmentMarkEntry>().Delete(AssignmentMarkEntry);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
