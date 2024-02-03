using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.MilitaryTrainings.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Handlers.Commands  
{ 
    public class DeleteMilitaryTrainingCommandHandler : IRequestHandler<DeleteMilitaryTrainingCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteMilitaryTrainingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteMilitaryTrainingCommand request, CancellationToken cancellationToken)
        {  
            var MilitaryTraining = await _unitOfWork.Repository<MilitaryTraining>().Get(request.Id);

            if (MilitaryTraining == null)  
                throw new NotFoundException(nameof(MilitaryTraining), request.Id);
             
            await _unitOfWork.Repository<MilitaryTraining>().Delete(MilitaryTraining); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}