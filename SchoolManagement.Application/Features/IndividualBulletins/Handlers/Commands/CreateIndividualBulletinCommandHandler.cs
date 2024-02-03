using AutoMapper;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using SchoolManagement.Application.Responses;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Commands;
using SchoolManagement.Application.DTOs.IndividualBulletins.Validators;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Commands
{
    public class CreateIndividualBulletinCommandHandler : IRequestHandler<CreateIndividualBulletinCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateIndividualBulletinCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateIndividualBulletinCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var bulletins = new List<IndividualBulletin>();

            var bulletinList = request.IndividualBulletinDto;
            //bulletinList.EndDate = bulletinList.EndDate.Value.AddDays(1.0);

            foreach (var item in bulletinList.TraineeListForm)
            {  
                if (item.IsNotify == true)
                {
                    bulletins = bulletinList.TraineeListForm.Where(x=>x.IsNotify==true).Select(x => new IndividualBulletin()
                    {
                        CourseDurationId = bulletinList.CourseDurationId,
                        BaseSchoolNameId = bulletinList.BaseSchoolNameId,
                        CourseNameId = bulletinList.CourseNameId,
                        TraineeNominationId = bulletinList.TraineeNominationId,
                        CourseInstructorId = x.CourseInstructorId,
                        TraineeId =x.TraineeId,
                        Status = 0,
                        //EndDate = bulletinList.EndDate,
                        BulletinDetails = bulletinList.BulletinDetails
                    }).ToList();
                }
            }

            await _unitOfWork.Repository<IndividualBulletin>().AddRangeAsync(bulletins);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;
        }
    }
}
