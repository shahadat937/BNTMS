using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.CourseWeeks;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.Features.CourseWeeks.Requests.Queries;
using SchoolManagement.Application.Responses;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.CourseWeeks.Handlers.Queries
{
    public class GetAutoCourseWeekCountForBnaRequestHandler : IRequestHandler<GetAutoCourseWeekCountForBnaRequest, object>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISchoolManagementRepository<CourseWeek> _CourseWeekRepository;
        private readonly ISchoolManagementRepository<CourseDuration> _CourseDurationRepository;
        private readonly ISchoolManagementRepository<BnaSemesterDuration> _BnaSemesterDurationRepository;
       
        public GetAutoCourseWeekCountForBnaRequestHandler(ISchoolManagementRepository<CourseWeek> CourseWeekRepository, ISchoolManagementRepository<BnaSemesterDuration> BnaSemesterDurationRepository, ISchoolManagementRepository<CourseDuration> CourseDurationRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _CourseWeekRepository = CourseWeekRepository;
            _CourseDurationRepository = CourseDurationRepository;
            _BnaSemesterDurationRepository = BnaSemesterDurationRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public async Task<object> Handle(GetAutoCourseWeekCountForBnaRequest request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();


            var BnaSemesterDuration = _BnaSemesterDurationRepository.FinedOneInclude(x => x.BnaSemesterDurationId == request.BnaSemesterDurationId);
            var FindCourseWeek = _CourseWeekRepository.FinedOneInclude(x => x.CourseDurationId == BnaSemesterDuration.CourseDurationId);
            var CourseDuration = _CourseDurationRepository.FinedOneInclude(x => x.CourseDurationId == BnaSemesterDuration.CourseDurationId);
            //var PCourseDurationId = _CourseWeekRepository.FinedOneInclude(x => x.CourseDurationId == BnaSemesterDuration.CourseDurationId);

            DateTime startDate, endDate;

            List<CourseWeek> courseWeeks = new List<CourseWeek>();
            //DateTime[] startDate1 = new DateTime[20], endDate1 =new DateTime[20];
            int i = 1;
            //if (&& BnaSemesterDuration.CourseDurationId == FindCourseWeek.CourseDurationId
          //      FindCourseWeek.BnaSemesterDurationId != BnaSemesterDuration.BnaSemesterDurationId
             //   )
          //  {
                for (startDate = Convert.ToDateTime(BnaSemesterDuration.StartDate); startDate <= Convert.ToDateTime(BnaSemesterDuration.EndDate); startDate = startDate.AddDays(7))
                {
                    var courseWeek = new CourseWeek()
                    {
                        CourseDurationId = BnaSemesterDuration.CourseDurationId,
                        BnaSemesterDurationId = BnaSemesterDuration.BnaSemesterDurationId,
                        CourseNameId = CourseDuration.CourseNameId,
                        BaseSchoolNameId = 2,// FindCourseWeek.BaseSchoolNameId,
                        DateFrom = startDate,
                        DateTo = startDate.AddDays(6),
                        WeekName = Convert.ToString(i + " Week"),
                        Status = 0,
                        IsActive = true
                    };
                   // var CourseWeekId = await _unitOfWork.Repository<CourseWeek>().Get(FindCourseWeek.CourseWeekId-1+i);
                    
                   // if (CourseWeekId is null)
                     //   throw new NotFoundException(nameof(CourseWeek), FindCourseWeek.CourseWeekId);

                   

                    i++;
                   // _mapper.Map(courseWeek, CourseWeekId);
                    courseWeeks.Add(courseWeek);

                  // await _unitOfWork.Repository<CourseWeek>().Update(CourseWeekId);
                  //  await _unitOfWork.Save();

        // await _unitOfWork.Repository<CourseWeek>().AddRangeAsync(courseWeeks);
                   //   await _unitOfWork.Save();
                }
           // }

            await _unitOfWork.Repository<CourseWeek>().AddRangeAsync(courseWeeks);
             await _unitOfWork.Save();


            response.Success = true;
            response.Message = "Creation Successful";

            return response;


        }
    }
}
