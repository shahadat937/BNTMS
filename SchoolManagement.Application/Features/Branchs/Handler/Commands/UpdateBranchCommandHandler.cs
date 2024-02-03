using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Branchs.Handler.Commands
{
    public class UpdateBranchCommandHandler : IRequestHandler<UpdateBranchCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBranchCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBranchCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateBranchDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BranchDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var branch = await _unitOfWork.Repository<Branch>().Get(request.BranchDto.BranchId);

            if (branch is null)
                throw new NotFoundException(nameof(branch), request.BranchDto.BranchId);

            _mapper.Map(request.BranchDto, branch);

            await _unitOfWork.Repository<Branch>().Update(branch);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}