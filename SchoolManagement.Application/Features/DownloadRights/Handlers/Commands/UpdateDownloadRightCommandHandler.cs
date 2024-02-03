using SchoolManagement.Domain;
using AutoMapper;
using MediatR;
using SchoolManagement.Application.DTOs.DownloadRight.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.DownloadRights.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DownloadRights.Handlers.Commands
{
    public class UpdateDownloadRightCommandHandler : IRequestHandler<UpdateDownloadRightCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDownloadRightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateDownloadRightCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateDownloadRightDtoValidator(); 
             var validationResult = await validator.ValidateAsync(request.DownloadRightDto);

            if (validationResult.IsValid == false)
                throw new ValidationException(validationResult);

            var DownloadRight = await _unitOfWork.Repository<DownloadRight>().Get(request.DownloadRightDto.DownloadRightId);

            if (DownloadRight is null)
                throw new NotFoundException(nameof(DownloadRight), request.DownloadRightDto.DownloadRightId);

            _mapper.Map(request.DownloadRightDto, DownloadRight);

            await _unitOfWork.Repository<DownloadRight>().Update(DownloadRight);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
}
