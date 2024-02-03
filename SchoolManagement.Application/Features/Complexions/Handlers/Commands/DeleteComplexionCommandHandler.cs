using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.Complexions.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Complexions.Handler.Commands 
{
    public class DeleteComplexionCommandHandler : IRequestHandler<DeleteComplexionsCommand> 
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public DeleteComplexionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteComplexionsCommand request, CancellationToken cancellationToken)
        {
            var complexion = await _unitOfWork.Repository<Complexion>().Get(request.Id);
             
            if (complexion == null) 
                throw new NotFoundException(nameof(Complexion), request.Id); 

            await _unitOfWork.Repository<Complexion>().Delete(complexion);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}