using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.GlobalSearch.Requests.Queries;
using SchoolManagement.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManagement.Application.DTOs.GlobalSearch;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.CourseDurations;

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class GetSearchedInstructorDetailRequestHandler: IRequestHandler<GetSearchedInstructorDetailRequest,object>
    {
        private readonly ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> _TraineeInfoRepo;
        private readonly ISchoolManagementRepository<Domain.CourseInstructor> _CourseInstructorRepo;
        private readonly ISchoolManagementRepository<Domain.CourseDuration> _CourseDurationRepo;
        private readonly IMapper _mapper;

        public GetSearchedInstructorDetailRequestHandler(ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> TraineeInfoRepo,
           ISchoolManagementRepository<Domain.CourseInstructor> CourseInstructorRepo,
           ISchoolManagementRepository<Domain.CourseDuration> CourseDurationRepo,
           IMapper mapper)
        {
            _TraineeInfoRepo = TraineeInfoRepo;
            _CourseInstructorRepo = CourseInstructorRepo;
            _CourseDurationRepo = CourseDurationRepo;
            _mapper = mapper;
        }
        public async Task<object> Handle(GetSearchedInstructorDetailRequest request, CancellationToken cancellationToken)
        {
            var instructor = await _TraineeInfoRepo.Get(request.instructorId);

            if(instructor == null)
            {
                throw new NotFoundException(nameof(instructor), request.instructorId);
            }

            var instructorDetail = new SearchedInstructorDetailDto();

            var courseDurationIds = await _CourseInstructorRepo.Where(x => x.TraineeId == request.instructorId).Select(x => x.CourseDurationId).Distinct().ToListAsync();

            var courseDurations = await _CourseDurationRepo.Where(x => courseDurationIds.Contains(x.CourseDurationId))
                .Include(x=>x.CourseName).ToListAsync();

            instructorDetail.CourseDurations = _mapper.Map<List<CourseDurationDto>>(courseDurations);
            instructorDetail.TotalCourse = instructorDetail.CourseDurations.Count();
            instructorDetail.PreviousCourse = instructorDetail.CourseDurations.Where(x => x.DurationTo < DateTime.Now).Count();
            instructorDetail.RunningCourse = instructorDetail.CourseDurations.Where(x => x.DurationFrom <= DateTime.Now && x.DurationTo >= DateTime.Now).Count();
            instructorDetail.UpcomingCourse = instructorDetail.CourseDurations.Where(x => x.DurationFrom > DateTime.Now).Count();

            return instructorDetail;
        }
    }
}
