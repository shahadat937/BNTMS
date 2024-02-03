using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecQuestionName.Validators;
using SchoolManagement.Application.Features.TdecQuestionNames.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TdecQuestionNames.Handlers.Commands
{
    public class CreateTdecQuestionNameCommandHandler : IRequestHandler<CreateTdecQuestionNameCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTdecQuestionNameCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTdecQuestionNameCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTdecQuestionNameDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TdecQuestionNameDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var TdecQuestionName = _mapper.Map<TdecQuestionName>(request.TdecQuestionNameDto);

                TdecQuestionName = await _unitOfWork.Repository<TdecQuestionName>().Add(TdecQuestionName);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = TdecQuestionName.TdecQuestionNameId;
            }

            return response;
        }
    }
}
