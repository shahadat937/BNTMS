using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.EducationalInstitutions.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Handlers.Commands
{  
    public class UpdateEducationalInstitutionCommandHandler : IRequestHandler<UpdateEducationalInstitutionCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateEducationalInstitutionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateEducationalInstitutionCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateEducationalInstitutionDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.EducationalInstitutionDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var EducationalInstitution = await _unitOfWork.Repository<EducationalInstitution>().Get(request.EducationalInstitutionDto.EducationalInstitutionId); 

            if (EducationalInstitution is null)  
                throw new NotFoundException(nameof(EducationalInstitution), request.EducationalInstitutionDto.EducationalInstitutionId); 

            _mapper.Map(request.EducationalInstitutionDto, EducationalInstitution);  

            await _unitOfWork.Repository<EducationalInstitution>().Update(EducationalInstitution); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}