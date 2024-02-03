using AutoMapper;
using SchoolManagement.Application.DTOs.CoCurricularActivity.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CoCurricularActivities.Requests.Commands;
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

namespace SchoolManagement.Application.Features.CoCurricularActivities.Handlers.Commands
{
    public class CreateCoCurricularActivityCommandHandler : IRequestHandler<CreateCoCurricularActivityCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCoCurricularActivityCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCoCurricularActivityCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateCoCurricularActivityDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CoCurricularActivityDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var CoCurricularActivity = _mapper.Map<CoCurricularActivity>(request.CoCurricularActivityDto);

                CoCurricularActivity = await _unitOfWork.Repository<CoCurricularActivity>().Add(CoCurricularActivity);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = CoCurricularActivity.CoCurricularActivityId;
            }

            return response;
        }
    }
}
