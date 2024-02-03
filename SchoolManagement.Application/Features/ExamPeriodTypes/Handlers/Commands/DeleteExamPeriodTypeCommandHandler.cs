using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamPeriodTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamPeriodTypes.Handlers.Commands
{
    public class DeleteExamPeriodTypeCommandHandler : IRequestHandler<DeleteExamPeriodTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExamPeriodTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExamPeriodTypeCommand request, CancellationToken cancellationToken)
        {
            var ExamPeriodType = await _unitOfWork.Repository<ExamPeriodType>().Get(request.ExamPeriodTypeId);

            if (ExamPeriodType == null)
                throw new NotFoundException(nameof(ExamPeriodType), request.ExamPeriodTypeId);

            await _unitOfWork.Repository<ExamPeriodType>().Delete(ExamPeriodType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
