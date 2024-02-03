using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.GuestSpeakerQuationGroups.Handlers.Commands
{
    public class CreateGuestSpeakerQuationGroupCommandHandler : IRequestHandler<CreateGuestSpeakerQuationGroupCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateGuestSpeakerQuationGroupCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateGuestSpeakerQuationGroupCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var guestSpeakerQuationList = request.GuestSpeakerQuationGroupDto;

            var GuestSpeakerQuationList = guestSpeakerQuationList.TraineeListForm.Select(x => new GuestSpeakerQuationGroup()
            {

                BaseSchoolNameId = guestSpeakerQuationList.BaseSchoolNameId,
                CourseNameId = guestSpeakerQuationList.CourseNameId,
                BnaSubjectNameId = guestSpeakerQuationList.BnaSubjectNameIds,
                CourseDurationId = guestSpeakerQuationList.CourseDurationId,
                TraineeId = guestSpeakerQuationList.TraineeId,
                GuestSpeakerQuestionNameId = x.GuestSpeakerQuestionNameId,
                Status = x.Status
            });

            var filteredGuestSpeakerList = GuestSpeakerQuationList.Where(x => x.Status == true);

            await _unitOfWork.Repository<GuestSpeakerQuationGroup>().AddRangeAsync(filteredGuestSpeakerList);
            try
            {
                await _unitOfWork.Save();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }


            response.Success = true;
            response.Message = "Creation Successful";
         //   response.Id = filteredGuestSpeakerList.Select(x => x.GuestSpeakerQuationGroupId).FirstOrDefault();


            return response;
        }
    }
}
