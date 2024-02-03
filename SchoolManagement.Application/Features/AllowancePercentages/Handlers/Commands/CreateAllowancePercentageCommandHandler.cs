using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AllowancePercentage.Validators;
using SchoolManagement.Application.Features.AllowancePercentages.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowancePercentages.Handlers.Commands
{
    public class CreateAllowancePercentageCommandHandler : IRequestHandler<CreateAllowancePercentageCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAllowancePercentageCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAllowancePercentageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAllowancePercentageDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AllowancePercentageDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AllowancePercentage = _mapper.Map<AllowancePercentage>(request.AllowancePercentageDto);

                AllowancePercentage = await _unitOfWork.Repository<AllowancePercentage>().Add(AllowancePercentage);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AllowancePercentage.AllowancePercentageId;
            }

            return response;
        }
    }
}
