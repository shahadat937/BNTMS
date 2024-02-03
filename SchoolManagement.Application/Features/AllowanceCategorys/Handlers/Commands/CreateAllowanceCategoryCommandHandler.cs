using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.AllowanceCategory.Validators;
using SchoolManagement.Application.Features.AllowanceCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.AllowanceCategorys.Handlers.Commands
{
    public class CreateAllowanceCategoryCommandHandler : IRequestHandler<CreateAllowanceCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAllowanceCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAllowanceCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateAllowanceCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.AllowanceCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var AllowanceCategory = _mapper.Map<AllowanceCategory>(request.AllowanceCategoryDto);

                AllowanceCategory = await _unitOfWork.Repository<AllowanceCategory>().Add(AllowanceCategory);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = AllowanceCategory.AllowanceCategoryId;
            }

            return response;
        }
    }
}
