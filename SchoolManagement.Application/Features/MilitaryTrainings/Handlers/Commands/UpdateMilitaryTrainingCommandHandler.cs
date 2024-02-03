using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.MilitaryTraining.Validators;
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
    public class UpdateMilitaryTrainingCommandHandler : IRequestHandler<UpdateMilitaryTrainingCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateMilitaryTrainingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateMilitaryTrainingCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateMilitaryTrainingDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.MilitaryTrainingDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var MilitaryTraining = await _unitOfWork.Repository<MilitaryTraining>().Get(request.MilitaryTrainingDto.MilitaryTrainingId); 

            if (MilitaryTraining is null)  
                throw new NotFoundException(nameof(MilitaryTraining), request.MilitaryTrainingDto.MilitaryTrainingId); 

            _mapper.Map(request.MilitaryTrainingDto, MilitaryTraining);  

            await _unitOfWork.Repository<MilitaryTraining>().Update(MilitaryTraining); 
            //await _unitOfWork.Save();
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex);
            }

            return Unit.Value;
        }
    }
}