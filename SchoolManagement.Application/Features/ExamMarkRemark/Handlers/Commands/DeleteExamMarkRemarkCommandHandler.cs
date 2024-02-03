using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamMarkRemark.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamMarkRemark.Handlers.Commands
{
    public class DeleteExamMarkRemarkCommandHandler : IRequestHandler<DeleteExamMarkRemarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExamMarkRemarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExamMarkRemarkCommand request, CancellationToken cancellationToken)
        {
            var ExamMarkRemark = await _unitOfWork.Repository<ExamMarkRemarks>().Get(request.ExamMarkRemarksId);

            if (ExamMarkRemark == null)
                throw new NotFoundException(nameof(ExamMarkRemark), request.ExamMarkRemarksId);

            await _unitOfWork.Repository<ExamMarkRemarks>().Delete(ExamMarkRemark);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
