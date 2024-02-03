using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.NewEntryEvaluations.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.NewEntryEvaluations.Handlers.Commands
{
    public class DeleteNewEntryEvaluationCommandHandler : IRequestHandler<DeleteNewEntryEvaluationCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteNewEntryEvaluationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteNewEntryEvaluationCommand request, CancellationToken cancellationToken)
        {
            var NewEntryEvaluation = await _unitOfWork.Repository<NewEntryEvaluation>().Get(request.NewEntryEvaluationId);

            if (NewEntryEvaluation == null)
                throw new NotFoundException(nameof(NewEntryEvaluation), request.NewEntryEvaluationId);

            await _unitOfWork.Repository<NewEntryEvaluation>().Delete(NewEntryEvaluation);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
