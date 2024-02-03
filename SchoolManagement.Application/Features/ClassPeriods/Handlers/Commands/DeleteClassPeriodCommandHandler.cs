using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassPeriods.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassPeriods.Handlers.Commands
{
    public class DeleteClassPeriodCommandHandler : IRequestHandler<DeleteClassPeriodCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteClassPeriodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteClassPeriodCommand request, CancellationToken cancellationToken)
        {
            var ClassPeriod = await _unitOfWork.Repository<ClassPeriod>().Get(request.ClassPeriodId);

            if (ClassPeriod == null)
                throw new NotFoundException(nameof(ClassPeriod), request.ClassPeriodId);

            await _unitOfWork.Repository<ClassPeriod>().Delete(ClassPeriod);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
