using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaExamInstructorAssigns.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaExamInstructorAssigns.Handlers.Commands
{
    public class DeleteBnaExamInstructorAssignCommandHandler : IRequestHandler<DeleteBnaExamInstructorAssignCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaExamInstructorAssignCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaExamInstructorAssignCommand request, CancellationToken cancellationToken)
        {
            var BnaExamInstructorAssign = await _unitOfWork.Repository<BnaExamInstructorAssign>().Get(request.BnaExamInstructorAssignId);

            if (BnaExamInstructorAssign == null)
                throw new NotFoundException(nameof(BnaExamInstructorAssign), request.BnaExamInstructorAssignId);

            await _unitOfWork.Repository<BnaExamInstructorAssign>().Delete(BnaExamInstructorAssign);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
