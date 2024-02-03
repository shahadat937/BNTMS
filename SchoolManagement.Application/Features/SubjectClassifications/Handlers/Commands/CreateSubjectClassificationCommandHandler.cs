using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SchoolManagement.Application.Responses;
using System.Linq;
using SchoolManagement.Application.Features.SubjectClassifications.Requests.Commands;
using SchoolManagement.Application.DTOs.SubjectClassifications.Validators;

namespace SchoolManagement.Application.Features.SubjectClassifications.Handlers.Commands
{
    public class CreateSubjectClassificationCommandHandler : IRequestHandler<CreateSubjectClassificationCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSubjectClassificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateSubjectClassificationCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSubjectClassificationDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SubjectClassificationDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SubjectClassification = _mapper.Map<SubjectClassification>(request.SubjectClassificationDto);

                SubjectClassification = await _unitOfWork.Repository<SubjectClassification>().Add(SubjectClassification);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SubjectClassification.SubjectClassificationId;
            }

            return response;
        }
    }
}
