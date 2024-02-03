using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.Complexion.Validators;
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
    public class UpdateComplexionCommandHandler : IRequestHandler<UpdateComplexionsCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper; 
         
        public UpdateComplexionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
         
        public async Task<Unit> Handle(UpdateComplexionsCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateComplexionDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.ComplexionDto); 

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var complexion = await _unitOfWork.Repository<Complexion>().Get(request.ComplexionDto.ComplexionId);
             
            if (complexion is null) 
                throw new NotFoundException(nameof(complexion), request.ComplexionDto.ComplexionId); 

            _mapper.Map(request.ComplexionDto, complexion); 

            await _unitOfWork.Repository<Complexion>().Update(complexion); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
