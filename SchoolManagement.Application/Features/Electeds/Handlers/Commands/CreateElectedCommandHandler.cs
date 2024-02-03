using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.Electeds.Validators;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.Electeds.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Electeds.Handlers.Commands   
{
    public class CreateElectedCommandHandler : IRequestHandler<CreateElectedCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateElectedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateElectedCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateElectedDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.ElectedDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var Elected = _mapper.Map<Elected>(request.ElectedDto); 

                Elected = await _unitOfWork.Repository<Elected>().Add(Elected);
                
                    await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = Elected.ElectedId;
            }

            return response;
        }
    }
}
