using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Features.IndividualNotices.Requests.Commands;
using SchoolManagement.Application.DTOs.IndividualNotices.Validators;

namespace SchoolManagement.Application.Features.IndividualNotices.Handlers.Commands
{
    public class CreateIndividualNoticeCommandHandler : IRequestHandler<CreateIndividualNoticeCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIndividualNoticeCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateIndividualNoticeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var notices = new List<IndividualNotice>();

            var noticeList = request.IndividualNoticeDto;
            noticeList.EndDate = noticeList.EndDate.Value.AddDays(1.0);

            foreach (var item in noticeList.TraineeListForm)
            {  
                if (item.IsNotify == true)
                {
                    notices = noticeList.TraineeListForm.Where(x=>x.IsNotify==true).Select(x => new IndividualNotice()
                    {
                        CourseDurationId = noticeList.CourseDurationId,
                        BaseSchoolNameId = noticeList.BaseSchoolNameId,
                        CourseNameId = noticeList.CourseNameId,
                        TraineeNominationId = noticeList.TraineeNominationId,
                        CourseInstructorId = noticeList.CourseInstructorId,
                        TraineeId =x.TraineeId,
                        Status = 0,
                        EndDate = noticeList.EndDate,
                        NoticeDetails = noticeList.NoticeDetails
                    }).ToList();
                }
            }

            await _unitOfWork.Repository<IndividualNotice>().AddRangeAsync(notices);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
