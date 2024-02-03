using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.Weights.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Weights.Handlers.Commands  
{ 
    public class DeleteWeightCommandHandler : IRequestHandler<DeleteWeightCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteWeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteWeightCommand request, CancellationToken cancellationToken)
        {  
            var weight = await _unitOfWork.Repository<Weight>().Get(request.Id);

            if (weight == null)  
                throw new NotFoundException(nameof(Weight), request.Id);
             
            await _unitOfWork.Repository<Weight>().Delete(weight); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}