using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Commands
{
    public class DeleteClassRoutineCommandHandler : IRequestHandler<DeleteClassRoutineCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteClassRoutineCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteClassRoutineCommand request, CancellationToken cancellationToken)
        {
            var ClassRoutines = await _unitOfWork.Repository<ClassRoutine>().Get(request.ClassRoutineId);

            if (ClassRoutines == null)
                throw new NotFoundException(nameof(ClassRoutine), request.ClassRoutineId);

            await _unitOfWork.Repository<ClassRoutine>().Delete(ClassRoutines);
          
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
