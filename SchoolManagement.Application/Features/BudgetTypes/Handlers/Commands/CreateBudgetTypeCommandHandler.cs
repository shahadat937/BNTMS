using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetType.Validators;
using SchoolManagement.Application.Features.BudgetTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BudgetTypes.Handlers.Commands
{
    public class CreateBudgetTypeCommandHandler : IRequestHandler<CreateBudgetTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBudgetTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBudgetTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBudgetTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BudgetType = _mapper.Map<BudgetType>(request.BudgetTypeDto);

                BudgetType = await _unitOfWork.Repository<BudgetType>().Add(BudgetType);
                await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BudgetType.BudgetTypeId;
            }

            return response;
        }
    }
}
