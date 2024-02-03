using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.Department.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Departments.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text; 
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Departments.Handlers.Commands
{
    public class UpdateDepartmentCommandHandler: IRequestHandler<UpdateDepartmentCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDepartmentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDepartmentCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDepartmentDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DepartmentDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var Department = await _unitOfWork.Repository<Department>().Get(request.DepartmentDto.DepartmentId);

            if (Department is null)
                throw new NotFoundException(nameof(Department), request.DepartmentDto.DepartmentId);

            _mapper.Map(request.DepartmentDto, Department);

            await _unitOfWork.Repository<Department>().Update(Department);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
