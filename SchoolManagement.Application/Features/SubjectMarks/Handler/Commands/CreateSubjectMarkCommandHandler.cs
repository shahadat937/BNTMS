using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.SubjectMark.Validators;
using SchoolManagement.Application.Features.SubjectMarks.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.SubjectMarks.Handler.Queries
{
    public class CreateSubjectMarkCommandHandler : IRequestHandler<CreateSubjectMarkCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
         
        public CreateSubjectMarkCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseCommandResponse> Handle(CreateSubjectMarkCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateSubjectMarkDtoValidator();
            var validationResult = await validator.ValidateAsync(request.SubjectMarkDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var SubjectMark = _mapper.Map<SubjectMark>(request.SubjectMarkDto);

                SubjectMark = await _unitOfWork.Repository<SubjectMark>().Add(SubjectMark);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                response.Id = SubjectMark.SubjectMarkId;
            }

            return response;
        }
    }
}
