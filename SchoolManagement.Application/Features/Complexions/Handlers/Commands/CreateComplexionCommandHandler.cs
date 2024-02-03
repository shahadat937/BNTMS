using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.Complexion.Validators;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.Complexions.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Complexions.Handler.Commands 
{
    public class CreateComplexionCommandHandler : IRequestHandler<CreateComplexionsCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;
         
        public CreateComplexionCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;   
            _mapper = mapper;
        } 
        public async Task<BaseCommandResponse> Handle(CreateComplexionsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateComplexionDtoValidator();
            var validationResult = await validator.ValidateAsync(request.ComplexionDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            { 
                var complexion = _mapper.Map<Complexion>(request.ComplexionDto);

                complexion = await _unitOfWork.Repository<Complexion>().Add(complexion);   
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = complexion.ComplexionId;
            }

            return response;
        }
    }
}
