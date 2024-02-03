using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TdecGroupResult.Validators;
using SchoolManagement.Application.Features.TdecGroupResults.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TdecGroupResults.Handlers.Commands
{
    public class CreateTdecGroupResultCommandHandler : IRequestHandler<CreateTdecGroupResultCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTdecGroupResultCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTdecGroupResultCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateTdecGroupResultDtoValidator();
            var validationResult = await validator.ValidateAsync(request.TdecGroupResultDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var tdecGroupResultList = request.TdecGroupResultDto;

                var tdecQuestionGroups = tdecGroupResultList.ApproveTraineeListForm.Select(x => new TdecGroupResult()
                {
                    TdecQuationGroupId = x.TdecQuationGroupId,
                    BaseSchoolNameId = x.BaseSchoolNameId,
                    CourseNameId=x.CourseNameId,
                    CourseDurationId = x.CourseDurationId,
                    BnaSubjectNameId =x.BnaSubjectNameId,
                    InstructorId =x.TraineeId,
                    TdecQuestionNameId = x.TdecQuestionNameId,
                    TdecActionStatusId =x.TdecActionStatusId,
                    TraineeId = tdecGroupResultList.TraineeId,
                    Status = false,
                    MenuPosition =tdecGroupResultList.MenuPosition,
                    IsActive = tdecGroupResultList.IsActive
                });

                 
                await _unitOfWork.Repository<TdecGroupResult>().AddRangeAsync(tdecQuestionGroups);
                await _unitOfWork.Save();

                response.Success = true;
                response.Message = "Creation Successful";
                //response.Id = TdecGroupResult.TdecGroupResultId;
            }

            return response;
        }
    }
}
