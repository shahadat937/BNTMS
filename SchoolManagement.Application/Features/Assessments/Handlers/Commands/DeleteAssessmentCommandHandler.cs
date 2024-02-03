using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Assessments.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Assessments.Handlers.Commands
{
    public class DeleteAssessmentCommandHandler : IRequestHandler<DeleteAssessmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAssessmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteAssessmentCommand request, CancellationToken cancellationToken)
        {
            var Assessment = await _unitOfWork.Repository<Assessment>().Get(request.AssessmentId);

            if (Assessment == null)
                throw new NotFoundException(nameof(Assessment), request.AssessmentId);

            await _unitOfWork.Repository<Assessment>().Delete(Assessment);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
