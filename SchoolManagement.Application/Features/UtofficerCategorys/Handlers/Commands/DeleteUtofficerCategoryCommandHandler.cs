using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.UtofficerCategorys.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.UtofficerCategorys.Handlers.Commands
{
    public class DeleteUtofficerCategoryCommandHandler : IRequestHandler<DeleteUtofficerCategoryCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteUtofficerCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteUtofficerCategoryCommand request, CancellationToken cancellationToken)
        {
            var UtofficerCategory = await _unitOfWork.Repository<UtofficerCategory>().Get(request.UtofficerCategoryId);

            if (UtofficerCategory == null)
                throw new NotFoundException(nameof(UtofficerCategory), request.UtofficerCategoryId);

            await _unitOfWork.Repository<UtofficerCategory>().Delete(UtofficerCategory);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
