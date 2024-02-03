using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.EducationalInstitutions.Validators;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Handlers.Commands   
{
    public class CreateEducationalInstitutionCommandHandler : IRequestHandler<CreateEducationalInstitutionCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateEducationalInstitutionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateEducationalInstitutionCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEducationalInstitutionDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.EducationalInstitutionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var EducationalInstitution = _mapper.Map<EducationalInstitution>(request.EducationalInstitutionDto); 

                EducationalInstitution = await _unitOfWork.Repository<EducationalInstitution>().Add(EducationalInstitution);
                await _unitOfWork.Save();
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = EducationalInstitution.EducationalInstitutionId;
            }

            return response;
        }
    }
}
