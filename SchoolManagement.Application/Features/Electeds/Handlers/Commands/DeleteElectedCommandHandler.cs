using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.Electeds.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Electeds.Handlers.Commands  
{ 
    public class DeleteElectedCommandHandler : IRequestHandler<DeleteElectedCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteElectedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteElectedCommand request, CancellationToken cancellationToken)
        {  
            var Elected = await _unitOfWork.Repository<Elected>().Get(request.Id);

            if (Elected == null)  
                throw new NotFoundException(nameof(Elected), request.Id);
             
            await _unitOfWork.Repository<Elected>().Delete(Elected); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}