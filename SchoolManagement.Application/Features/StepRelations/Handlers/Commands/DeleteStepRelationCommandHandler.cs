using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.StepRelations.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.StepRelations.Handlers.Commands
{
    public class DeleteStepRelationCommandHandler : IRequestHandler<DeleteStepRelationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteStepRelationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteStepRelationCommand request, CancellationToken cancellationToken)
        {
            var StepRelation = await _unitOfWork.Repository<StepRelation>().Get(request.StepRelationId);

            if (StepRelation == null)
                throw new NotFoundException(nameof(StepRelation), request.StepRelationId);

            await _unitOfWork.Repository<StepRelation>().Delete(StepRelation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
