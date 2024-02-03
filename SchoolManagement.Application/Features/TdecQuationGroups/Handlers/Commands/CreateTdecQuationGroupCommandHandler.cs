using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.TdecQuationGroups.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TdecQuationGroups.Handlers.Commands
{
    public class CreateTdecQuationGroupCommandHandler : IRequestHandler<CreateTdecQuationGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTdecQuationGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTdecQuationGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var TdecQuationList = request.TdecQuationGroupDto;

            var tdecQuationList = TdecQuationList.TraineeListForm.Select(x => new TdecQuationGroup()
            {

                BaseSchoolNameId = TdecQuationList.BaseSchoolNameId,
                CourseNameId = TdecQuationList.CourseNameId,
                BnaSubjectNameId = TdecQuationList.BnaSubjectNameIds,
                CourseDurationId = TdecQuationList.CourseDurationId,
                TraineeId =TdecQuationList.TraineeId,
                TdecQuestionNameId = x.TdecQuestionNameId,
                Status = x.Status
            });

            var filteredTdecList = tdecQuationList.Where(x => x.Status == true);

            await _unitOfWork.Repository<TdecQuationGroup>().AddRangeAsync(filteredTdecList);
            await _unitOfWork.Save();


            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = filteredTdecList.Select(x => x.TdecQuationGroupId).FirstOrDefault();


            return response;
        }
    }
}
