using AutoMapper;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Features.BnaInstructorTypes.Requests.Commands;

namespace SchoolManagement.Application.Features.BnaInstructorTypes.Handlers.Commands
{ 
    public class DeleteBnaInstructorTypeCommandHandler : IRequestHandler<DeleteBnaInstructorTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBnaInstructorTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        { 
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteBnaInstructorTypeCommand request, CancellationToken cancellationToken)
        {
            var BnaInstructorType = await _unitOfWork.Repository<BnaInstructorType>().Get(request.BnaInstructorTypeId);

            if (BnaInstructorType == null)
                throw new NotFoundException(nameof(BnaInstructorType), request.BnaInstructorTypeId);

            await _unitOfWork.Repository<BnaInstructorType>().Delete(BnaInstructorType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
