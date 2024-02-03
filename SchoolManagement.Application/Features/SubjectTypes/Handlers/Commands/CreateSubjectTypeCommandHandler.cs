using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectTypes.Validators;
using SchoolManagement.Application.Features.SubjectTypes.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectTypes.Handlers.Commands
{
    public class CreateSubjectTypeCommandHandler : IRequestHandler<CreateSubjectTypeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSubjectTypeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSubjectTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSubjectTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SubjectTypeDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SubjectType = _mapper.Map<SubjectType>(request.SubjectTypeDto);

                SubjectType = await _unitOfWork.Repository<SubjectType>().Add(SubjectType);
                await _unitOfWork.Save();


                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SubjectType.SubjectTypeId;
            }

            return response;
        }
    }
}
