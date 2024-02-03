using AutoMapper;
using SchoolManagement.Application.DTOs.EducationalQualification.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.EducationalQualifications.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses; 
using System.Linq;

namespace SchoolManagement.Application.Features.EducationalQualifications.Handlers.Commands
{
    public class CreateEducationalQualificationCommandHandler : IRequestHandler<CreateEducationalQualificationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateEducationalQualificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateEducationalQualificationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateEducationalQualificationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.EducationalQualificationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var EducationalQualification = _mapper.Map<EducationalQualification>(request.EducationalQualificationDto);

                EducationalQualification = await _unitOfWork.Repository<EducationalQualification>().Add(EducationalQualification);

                await _unitOfWork.Save();
                
                
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = EducationalQualification.EducationalQualificationId;
            }

            return response;
        }
    }
}
