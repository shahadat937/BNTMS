using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.TraineeLanguages.Validators;
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
    public class UpdateTraineeLanguageCommandHandler : IRequestHandler<UpdateTraineeLanguageCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateTraineeLanguageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateTraineeLanguageCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateTraineeLanguageDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.TraineeLanguageDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var TraineeLanguage = await _unitOfWork.Repository<TraineeLanguage>().Get(request.TraineeLanguageDto.TraineeLanguageId); 

            if (TraineeLanguage is null)  
                throw new NotFoundException(nameof(TraineeLanguage), request.TraineeLanguageDto.TraineeLanguageId); 

            _mapper.Map(request.TraineeLanguageDto, TraineeLanguage);  

            await _unitOfWork.Repository<TraineeLanguage>().Update(TraineeLanguage); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}