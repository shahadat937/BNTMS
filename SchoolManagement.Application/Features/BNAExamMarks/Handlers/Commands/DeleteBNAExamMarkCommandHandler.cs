using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamMarks.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamMarks.Handlers.Commands
{
    public class DeleteBnaExamMarkCommandHandler : IRequestHandler<DeleteBnaExamMarkCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaExamMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaExamMarkCommand request, CancellationToken cancellationToken)
        {
            var BnaExamMarks = await _unitOfWork.Repository<BnaExamMark>().Get(request.BnaExamMarkId);

            if (BnaExamMarks == null)
                throw new NotFoundException(nameof(BnaExamMark), request.BnaExamMarkId);

            await _unitOfWork.Repository<BnaExamMark>().Delete(BnaExamMarks);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
