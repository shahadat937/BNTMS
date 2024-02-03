using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.Electeds.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.Electeds.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Electeds.Handlers.Commands
{  
    public class UpdateElectedCommandHandler : IRequestHandler<UpdateElectedCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateElectedCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateElectedCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateElectedDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.ElectedDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var Elected = await _unitOfWork.Repository<Elected>().Get(request.ElectedDto.ElectedId); 

            if (Elected is null)  
                throw new NotFoundException(nameof(Elected), request.ElectedDto.ElectedId); 

            _mapper.Map(request.ElectedDto, Elected);  

            await _unitOfWork.Repository<Elected>().Update(Elected); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}