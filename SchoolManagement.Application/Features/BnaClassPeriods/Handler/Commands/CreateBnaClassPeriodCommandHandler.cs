using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaClassPeriod.Validators;
using SchoolManagement.Application.Features.BnaClassPeriods.Requests.Commands;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassPeriods.Handler.Commands
{
    public class CreateBnaClassPeriodCommandHandler : IRequestHandler<CreateBnaClassPeriodCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaClassPeriodCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaClassPeriodCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaClassPeriodDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaClassPeriodDto);
            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaClassPeriod = _mapper.Map<SchoolManagement.Domain.BnaClassPeriod>(request.BnaClassPeriodDto);

                BnaClassPeriod = await _unitOfWork.Repository<SchoolManagement.Domain.BnaClassPeriod>().Add(BnaClassPeriod);


                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaClassPeriod.BnaClassPeriodId;
            }

            return response;
        }
    }
}
