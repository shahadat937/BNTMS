using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetAutoCourseWeekCountRequestHandler : IRequestHandler<GetAutoCourseWeekCountRequest, object>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISchoolManagementRepository<CourseWeek> _CourseWeekRepository;
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;
        public GetAutoCourseWeekCountRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository, ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _CourseWeekRepository = CourseWeekRepository;
            _CourseDurationRepository = CourseDurationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(GetAutoCourseWeekCountRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var CourseDuration = _CourseDurationRepository.FinedOneInclude(x => x.CourseDurationId == request.CourseDurationId);
            //var startDate = CourseDuration.DurationFrom;
            //var endDate = CourseDuration.DurationTo;
            DateTime startDate, endDate;

            List<CourseWeek> courseWeeks = new List<CourseWeek>();
            //DateTime[] startDate1 = new DateTime[20], endDate1 =new DateTime[20];
            int i = 1;
            for (startDate = Convert.ToDateTime(CourseDuration.DurationFrom); startDate <= Convert.ToDateTime(CourseDuration.DurationTo); startDate = startDate.AddDays(7))
            {
                var courseWeek = new CourseWeek()
                {
                    CourseDurationId = CourseDuration.CourseDurationId,
                    CourseNameId = CourseDuration.CourseNameId,
                    BaseSchoolNameId = CourseDuration.BaseSchoolNameId,
                    DateFrom = startDate,
                    DateTo = startDate.AddDays(6),
                    WeekName =Convert.ToString( i +" Week"),
                    Status = 0,
                    IsActive = true
                };
               
                i++;
                courseWeeks.Add(courseWeek);
            }

            await _unitOfWork.Repository<CourseWeek>().AddRangeAsync(courseWeeks);
            await _unitOfWork.Save();

            response.Success = true;
            response.Message = "Creation Successful";

            return response;


        }
    }
}
