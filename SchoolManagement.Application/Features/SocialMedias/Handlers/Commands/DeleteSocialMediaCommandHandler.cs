using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
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
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper; 

        public DeleteSocialMediaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<Unit> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {  
            var SocialMedia = await _unitOfWork.Repository<SocialMedia>().Get(request.Id);

            if (SocialMedia == null)  
                throw new NotFoundException(nameof(SocialMedia), request.Id);
             
            await _unitOfWork.Repository<SocialMedia>().Delete(SocialMedia); 
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}