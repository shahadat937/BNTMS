using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch.Validators;
using SchoolManagement.Application.DTOs.SocialMedias.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.Branchs.Requests.Commands;
using SchoolManagement.Application.Features.SocialMedias.Requests.Commands;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SocialMedias.Handlers.Commands
{  
    public class UpdateSocialMediaCommandHandler : IRequestHandler<UpdateSocialMediaCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork; 
        private readonly IMapper _mapper;

        public UpdateSocialMediaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateSocialMediaDtoValidator(); 
            var validationResult = await validator.ValidateAsync(request.SocialMediaDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult); 
             
            var SocialMedia = await _unitOfWork.Repository<SocialMedia>().Get(request.SocialMediaDto.SocialMediaId); 

            if (SocialMedia is null)  
                throw new NotFoundException(nameof(SocialMedia), request.SocialMediaDto.SocialMediaId); 

            _mapper.Map(request.SocialMediaDto, SocialMedia);  

            await _unitOfWork.Repository<SocialMedia>().Update(SocialMedia); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}