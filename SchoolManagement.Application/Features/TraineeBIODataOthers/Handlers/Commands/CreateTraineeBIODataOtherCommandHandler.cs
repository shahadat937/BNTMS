using AutoMapper;
using SchoolManagement.Application.DTOs.TraineeBioDataOther.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Commands;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Handlers.Commands
{
    public class CreateTraineeBioDataOtherCommandHandler : IRequestHandler<CreateTraineeBioDataOtherCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTraineeBioDataOtherCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTraineeBioDataOtherCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTraineeBioDataOtherDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TraineeBioDataOtherDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TraineeBioDataOther = _mapper.Map<TraineeBioDataOther>(request.TraineeBioDataOtherDto);

                TraineeBioDataOther = await _unitOfWork.Repository<TraineeBioDataOther>().Add(TraineeBioDataOther);

                    await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TraineeBioDataOther.TraineeBioDataOtherId;
            }

            return response;
        }
    }
}
