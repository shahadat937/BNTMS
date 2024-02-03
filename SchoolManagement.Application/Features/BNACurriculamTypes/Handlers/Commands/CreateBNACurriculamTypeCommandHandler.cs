using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaCurriculamType.Validators;
using SchoolManagement.Application.Features.BnaCurriculamTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaCurriculamTypes.Handlers.Commands
{
    public class CreateBnaCurriculamTypeCommandHandler : IRequestHandler<CreateBnaCurriculamTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaCurriculamTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaCurriculamTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaCurriculamTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaCurriculamTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaCurriculamType = _mapper.Map<BnaCurriculumType>(request.BnaCurriculamTypeDto);

                BnaCurriculamType = await _unitOfWork.Repository<BnaCurriculumType>().Add(BnaCurriculamType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaCurriculamType.BnaCurriculumTypeId;
            }

            return response;
        }
    }
}
