using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.MarkCategory.Validators;
using SchoolManagement.Application.Features.MarkCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.MarkCategorys.Handler.Queries
{
    public class CreateMarkCategoryCommandHandler : IRequestHandler<CreateMarkCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateMarkCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateMarkCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateMarkCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.MarkCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var MarkCategory = _mapper.Map<MarkCategory>(request.MarkCategoryDto);

                //MarkCategory.PolicyStatus = 0;
                MarkCategory = await _unitOfWork.Repository<MarkCategory>().Add(MarkCategory);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = MarkCategory.MarkCategoryId;
            }

            return response;
        }
    }
}
