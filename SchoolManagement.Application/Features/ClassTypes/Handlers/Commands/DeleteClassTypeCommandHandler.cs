using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.ClassTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassTypes.Handlers.Commands
{
    public class DeleteClassTypeCommandHandler : IRequestHandler<DeleteClassTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteClassTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteClassTypeCommand request, CancellationToken cancellationToken)
        {
            var ClassType = await _unitOfWork.Repository<ClassType>().Get(request.ClassTypeId);

            if (ClassType == null)
                throw new NotFoundException(nameof(ClassType), request.ClassTypeId);

            await _unitOfWork.Repository<ClassType>().Delete(ClassType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
