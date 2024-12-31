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
using Microsoft.AspNetCore.Http;
using System.Runtime.CompilerServices;
using SchoolManagement.Application.Contracts.Identity;
using SchoolManagement.Application.Constants;

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class GetSearchedInstructorDetailRequestHandler: IRequestHandler<GetSearchedInstructorDetailRequest,object>
    {
        private readonly ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> _TraineeInfoRepo;
        private readonly ISchoolManagementRepository<Domain.CourseInstructor> _CourseInstructorRepo;
        private readonly ISchoolManagementRepository<Domain.CourseDuration> _CourseDurationRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;

        public GetSearchedInstructorDetailRequestHandler(ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> TraineeInfoRepo,
           ISchoolManagementRepository<Domain.CourseInstructor> CourseInstructorRepo,
           ISchoolManagementRepository<Domain.CourseDuration> CourseDurationRepo,
           IMapper mapper,
           IHttpContextAccessor httpContextAccessor,
           IUserService userService)
        {
            _TraineeInfoRepo = TraineeInfoRepo;
            _CourseInstructorRepo = CourseInstructorRepo;
            _CourseDurationRepo = CourseDurationRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }
        public async Task<object> Handle(GetSearchedInstructorDetailRequest request, CancellationToken cancellationToken)
        {
            var instructor = await _TraineeInfoRepo.Get(request.instructorId);

            if(instructor == null)
            {
                throw new NotFoundException(nameof(instructor), request.instructorId);
            }

            // Get the search level
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            List<int?> branchId = new List<int?> { null, null, null };
            if (userId != null)
            {
                var user = await _userService.GetUserById(userId);
                if (user != null)
                {
                    branchId[0] = user.SecondLevel;
                    branchId[1] = user.ThirdLevel;
                    branchId[2] = user.FourthLevel;
                }
            }

            var instructorDetail = new SearchedInstructorDetailDto();

            var courseDurationIds = await _CourseInstructorRepo.Where(x => x.TraineeId == request.instructorId).Select(x => x.CourseDurationId).Distinct().ToListAsync();


            var courseDurations = _CourseDurationRepo.Where(x => true)
                .Include(x => x.CourseName)
                .Include(x => x.BaseSchoolName)
                .AsQueryable();
            courseDurations = courseDurations.Where(x => courseDurationIds.Contains(x.CourseDurationId));
            courseDurations = courseDurations.Where(x =>
                    (branchId[0] == null || x.BaseSchoolName == null || x.BaseSchoolName.SecondLevel == branchId[0]) &&
                    (branchId[1] == null || x.BaseSchoolName == null || x.BaseSchoolName.ThirdLevel == branchId[1]) &&
                    (branchId[2] == null || x.BaseSchoolName == null || x.BaseSchoolName.FourthLevel == branchId[2])
            );

            instructorDetail.CourseDurations = _mapper.Map<List<CourseDurationDto>>(await courseDurations.ToListAsync());
            instructorDetail.TotalCourse = instructorDetail.CourseDurations.Count();
            instructorDetail.PreviousCourse = instructorDetail.CourseDurations.Where(x => x.DurationTo < DateTime.Now).Count();
            instructorDetail.RunningCourse = instructorDetail.CourseDurations.Where(x => x.DurationFrom <= DateTime.Now && x.DurationTo >= DateTime.Now).Count();
            instructorDetail.UpcomingCourse = instructorDetail.CourseDurations.Where(x => x.DurationFrom > DateTime.Now).Count();

            return instructorDetail;
        }
    }
}
