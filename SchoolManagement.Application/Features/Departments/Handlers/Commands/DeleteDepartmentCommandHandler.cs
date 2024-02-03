using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Departments.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Departments.Handlers.Commands
{
    public class DeleteDepartmentCommandHandler: IRequestHandler<DeleteDepartmentCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteDepartmentCommand request, CancellationToken cancellationToken)
        {
            var Department = await _unitOfWork.Repository<Department>().Get(request.DepartmentId);

            if (Department == null)
                throw new NotFoundException(nameof(Department), request.DepartmentId);

            await _unitOfWork.Repository<Department>().Delete(Department);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
 