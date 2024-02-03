using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ExamTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ExamTypes.Handlers.Commands
{
    public class DeleteExamTypeCommandHandler : IRequestHandler<DeleteExamTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteExamTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteExamTypeCommand request, CancellationToken cancellationToken)
        {
            var ExamType = await _unitOfWork.Repository<ExamType>().Get(request.ExamTypeId);

            if (ExamType == null)
                throw new NotFoundException(nameof(ExamType), request.ExamTypeId);

            await _unitOfWork.Repository<ExamType>().Delete(ExamType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
