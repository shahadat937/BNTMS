using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.RecordOfService.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.RecordOfServices.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.RecordOfServices.Handlers.Commands
{  
    public class UpdateRecordOfServiceCommandHandler : IRequestHandler<UpdateRecordOfServiceCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateRecordOfServiceCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateRecordOfServiceCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateRecordOfServiceDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.RecordOfServiceDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var RecordOfService = await _unitOfWork.Repository<RecordOfService>().Get(request.RecordOfServiceDto.RecordOfServiceId); 

            if (RecordOfService is null)  
                throw new NotFoundException(nameof(RecordOfService), request.RecordOfServiceDto.RecordOfServiceId); 

            _mapper.Map(request.RecordOfServiceDto, RecordOfService);  

            await _unitOfWork.Repository<RecordOfService>().Update(RecordOfService); 
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