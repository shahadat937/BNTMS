using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RecordOfServices.Handlers.Commands  
{ 
    public class DeleteRecordOfServiceCommandHandler : IRequestHandler<DeleteRecordOfServiceCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteRecordOfServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteRecordOfServiceCommand request, CancellationToken cancellationToken)
        {  
            var RecordOfService = await _unitOfWork.Repository<RecordOfService>().Get(request.Id);

            if (RecordOfService == null)  
                throw new NotFoundException(nameof(RecordOfService), request.Id);
             
            await _unitOfWork.Repository<RecordOfService>().Delete(RecordOfService); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}