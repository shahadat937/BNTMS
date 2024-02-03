using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
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
    public class DeleteSocialMediaTypeCommandHandler : IRequestHandler<DeleteSocialMediaTypeCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteSocialMediaTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteSocialMediaTypeCommand request, CancellationToken cancellationToken)
        {  
            var SocialMediaType = await _unitOfWork.Repository<SocialMediaType>().Get(request.Id);

            if (SocialMediaType == null)  
                throw new NotFoundException(nameof(SocialMediaType), request.Id);
             
            await _unitOfWork.Repository<SocialMediaType>().Delete(SocialMediaType); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}