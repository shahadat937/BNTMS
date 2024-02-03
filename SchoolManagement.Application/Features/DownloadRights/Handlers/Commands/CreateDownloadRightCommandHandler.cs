using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.DownloadRight.Validators;
using SchoolManagement.Application.Features.DownloadRights.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.DownloadRights.Handlers.Commands
{
    public class CreateDownloadRightCommandHandler : IRequestHandler<CreateDownloadRightCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDownloadRightCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateDownloadRightCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateDownloadRightDtoValidator();
            var validationResult = await validator.ValidateAsync(request.DownloadRightDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var DownloadRight = _mapper.Map<DownloadRight>(request.DownloadRightDto);

                DownloadRight = await _unitOfWork.Repository<DownloadRight>().Add(DownloadRight);
                await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = DownloadRight.DownloadRightId;
            }

            return response;
        }
    }
}
