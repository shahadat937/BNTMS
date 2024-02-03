using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseDurations.Validators;
using SchoolManagement.Application.Features.CourseDurations.Requests.Commands;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Commands
{
    public class CreateCourseDurationForNbcdCommandHandler : IRequestHandler<CreateCourseDurationForNbcdCommand, BaseCommandResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCourseDurationForNbcdCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCourseDurationForNbcdCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
           
            //For insert operation
            var existingCourseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationDto.CourseDurationId);
          
            existingCourseDuration.CourseTitle = request.CourseDurationDto.CourseTitle;
            existingCourseDuration.Nbcd = request.CourseDurationDto.Nbcd;
            existingCourseDuration.DurationFrom = request.CourseDurationDto.NbcdDurationFrom;
            existingCourseDuration.DurationTo = request.CourseDurationDto.NbcdDurationTo;
            existingCourseDuration.BaseSchoolNameId = request.BaseSchoolNameId;
            existingCourseDuration.ComeFromNbcdDurationId = existingCourseDuration.CourseDurationId;
            existingCourseDuration.CourseDurationId = 0;
            existingCourseDuration.NbcdSchoolId = null;
            existingCourseDuration.NbcdDurationFrom = null;
            existingCourseDuration.NbcdDurationTo = null;
            existingCourseDuration.Professional = 0.ToString();
            existingCourseDuration.NbcdStatus = null;

            var CourseDuration = await _unitOfWork.Repository<CourseDuration>().Add(existingCourseDuration);
            await _unitOfWork.Save();

            //For Update Operation
            var courseDuration = await _unitOfWork.Repository<CourseDuration>().Get(request.CourseDurationDto.CourseDurationId);
            courseDuration.NbcdStatus = 1;

            await _unitOfWork.Repository<CourseDuration>().Update(courseDuration);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = CourseDuration.CourseDurationId;

            return response;
        }
    }
}
