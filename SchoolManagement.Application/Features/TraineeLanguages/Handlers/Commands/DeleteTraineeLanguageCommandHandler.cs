using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.TraineeLanguages.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeLanguages.Handlers.Commands  
{ 
    public class DeleteTraineeLanguageCommandHandler : IRequestHandler<DeleteTraineeLanguageCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteTraineeLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteTraineeLanguageCommand request, CancellationToken cancellationToken)
        {  
            var TraineeLanguage = await _unitOfWork.Repository<TraineeLanguage>().Get(request.Id);

            if (TraineeLanguage == null)  
                throw new NotFoundException(nameof(TraineeLanguage), request.Id);
             
            await _unitOfWork.Repository<TraineeLanguage>().Delete(TraineeLanguage); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}