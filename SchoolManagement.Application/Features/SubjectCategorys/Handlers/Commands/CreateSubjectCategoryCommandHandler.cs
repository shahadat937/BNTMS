using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectCategorys.Validators;
using SchoolManagement.Application.Features.SubjectCategorys.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectCategorys.Handlers.Commands
{
    public class CreateSubjectCategoryCommandHandler : IRequestHandler<CreateSubjectCategoryCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSubjectCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        } 

        public async Task<BaseCommandResponse> Handle(CreateSubjectCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSubjectCategoryDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SubjectCategoryDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SubjectCategory = _mapper.Map<SubjectCategory>(request.SubjectCategoryDto);

                SubjectCategory = await _unitOfWork.Repository<SubjectCategory>().Add(SubjectCategory);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SubjectCategory.SubjectCategoryId;
            }

            return response;
        }
    }
}
