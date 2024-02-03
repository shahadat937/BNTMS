using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.RecordOfService.Validators;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RecordOfServices.Handlers.Commands   
{
    public class CreateMilitaryTrainingCommandHandler : IRequestHandler<CreateRecordOfServiceCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateMilitaryTrainingCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateRecordOfServiceCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateRecordOfServiceDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.RecordOfServiceDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var RecordOfService = _mapper.Map<RecordOfService>(request.RecordOfServiceDto); 

                RecordOfService = await _unitOfWork.Repository<RecordOfService>().Add(RecordOfService);
                //await _unitOfWork.Save();
                try
                {
                    await _unitOfWork.Save();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex);
                }
                response.Success = true;
                response.Message = "Creation Successful"; 
                response.Id = RecordOfService.RecordOfServiceId;
            }

            return response;
        }
    }
}
