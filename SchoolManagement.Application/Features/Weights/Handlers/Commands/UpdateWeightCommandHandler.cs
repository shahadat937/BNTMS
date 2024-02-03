using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.Weight.Validators;
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
    public class UpdateWeightCommandHandler : IRequestHandler<UpdateWeightCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateWeightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateWeightCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateWeightDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.WeightDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var weight = await _unitOfWork.Repository<Weight>().Get(request.WeightDto.WeightId); 

            if (weight is null)  
                throw new NotFoundException(nameof(weight), request.WeightDto.WeightId); 

            _mapper.Map(request.WeightDto, weight);  

            await _unitOfWork.Repository<Weight>().Update(weight); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}