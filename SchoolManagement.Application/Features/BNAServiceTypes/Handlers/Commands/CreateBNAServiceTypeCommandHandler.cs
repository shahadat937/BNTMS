using AutoMapper;
using SchoolManagement.Application.DTOs.BnaServiceType.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.BnaServiceTypes.Requests.Commands;
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

namespace SchoolManagement.Application.Features.BnaServiceTypes.Handlers.Commands
{
    public class CreateBnaServiceTypeCommandHandler : IRequestHandler<CreateBnaServiceTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBnaServiceTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBnaServiceTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBnaServiceTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BnaServiceTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BnaServiceType = _mapper.Map<BnaServiceType>(request.BnaServiceTypeDto);

                BnaServiceType = await _unitOfWork.Repository<BnaServiceType>().Add(BnaServiceType);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BnaServiceType.BnaServiceTypeId;
            }

            return response;
        }
    }
}
