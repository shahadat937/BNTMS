using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BudgetCode.Validators;
using SchoolManagement.Application.Features.BudgetCodess.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.BudgetCodess.Handlers.Commands
{
    public class CreateBudgetCodeCommandHandler : IRequestHandler<CreateBudgetCodeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBudgetCodeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBudgetCodeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateBudgetCodeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.BudgetCodeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var BudgetCode = _mapper.Map<BudgetCode>(request.BudgetCodeDto);

                BudgetCode = await _unitOfWork.Repository<BudgetCode>().Add(BudgetCode);
                await _unitOfWork.Save();
                

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = BudgetCode.BudgetCodeId;
            }

            return response;
        }
    }
}
