using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.SocialMediaTypes.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.SocialMediaTypes.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Handlers.Commands
{  
    public class UpdateSocialMediaTypeCommandHandler : IRequestHandler<UpdateSocialMediaTypeCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateSocialMediaTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateSocialMediaTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSocialMediaTypeDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.SocialMediaTypeDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var SocialMediaType = await _unitOfWork.Repository<SocialMediaType>().Get(request.SocialMediaTypeDto.SocialMediaTypeId); 

            if (SocialMediaType is null)  
                throw new NotFoundException(nameof(SocialMediaType), request.SocialMediaTypeDto.SocialMediaTypeId); 

            _mapper.Map(request.SocialMediaTypeDto, SocialMediaType);  

            await _unitOfWork.Repository<SocialMediaType>().Update(SocialMediaType); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}