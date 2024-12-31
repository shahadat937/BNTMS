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
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.CourseDurations;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Constants;
using SchoolManagement.Application.Contracts.Identity;

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class GetSearchedTraineeDetailRequestHandler: IRequestHandler<GetSearchedTraineeDetailRequest,object>
    {
        private readonly ISchoolManagementRepository<Domain.CourseDuration> _CourseDurationRepo;
        private readonly ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> _TraineeInfoRepo;
        private readonly ISchoolManagementRepository<Domain.TraineeNomination> _TraineeNominationRepo;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUserService _userService;
        public GetSearchedTraineeDetailRequestHandler(ISchoolManagementRepository<Domain.CourseDuration> CourseDurationRepo,
            ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> TraineeInfoRepo,
            ISchoolManagementRepository<Domain.TraineeNomination> TraineeNominationRepo,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IUserService userService)
        {
            _CourseDurationRepo = CourseDurationRepo;
            _TraineeInfoRepo = TraineeInfoRepo;
            _TraineeNominationRepo = TraineeNominationRepo;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _userService = userService;
        }

        public async Task<object> Handle(GetSearchedTraineeDetailRequest request, CancellationToken cancellationToken)
        {
            // TODO: YET TO IMPLEMENT
            var trainee = await _TraineeInfoRepo.Get(request.TraineeId);

            if(trainee == null)
            {
                throw new NotFoundException(nameof(trainee), request.TraineeId);
            }

            // Get the search level
            var userId = _httpContextAccessor.HttpContext.User.FindFirst(CustomClaimTypes.Uid)?.Value;

            List<int?> branchId = new List<int?> { null,null,null};
            if (userId != null)
            {
                var user = await _userService.GetUserById(userId);
                if(user!=null)
                {
                    branchId[0] = user.SecondLevel;
                    branchId[1] = user.ThirdLevel;
                    branchId[2] = user.FourthLevel;
                }
            }

            var traineeDetail = new SearchedTraineeDetailDto();

            List<int?> courseDurationIds = await _TraineeNominationRepo.Where(x => x.TraineeId == request.TraineeId && x.TraineeId != null).Select(x =>x.CourseDurationId).Distinct().ToListAsync();

            var courseDurations = _CourseDurationRepo.Where(x => true)
                    .Include(x => x.CourseName)
                    .Include(x => x.BaseSchoolName).AsQueryable();
            courseDurations = courseDurations.Where(x => courseDurationIds.Contains(x.CourseDurationId));
            courseDurations = courseDurations.Where(x =>
                    (branchId[0] == null || x.BaseSchoolName == null || x.BaseSchoolName.SecondLevel == branchId[0]) &&
                    (branchId[1] == null || x.BaseSchoolName == null || x.BaseSchoolName.ThirdLevel == branchId[1]) &&
                    (branchId[2] == null || x.BaseSchoolName == null || x.BaseSchoolName.FourthLevel == branchId[2])
            );

            traineeDetail.CourseDurations = _mapper.Map<List<CourseDurationDto>>(await courseDurations.ToListAsync());
            traineeDetail.TotalCourse = traineeDetail.CourseDurations.Count();
            traineeDetail.PreviousCourse = traineeDetail.CourseDurations.Where(x => x.DurationTo < DateTime.Now).Count();
            traineeDetail.RunningCourse = traineeDetail.CourseDurations.Where(x=> x.DurationFrom <= DateTime.Now && x.DurationTo >= DateTime.Now).Count();
            traineeDetail.UpcomingCourse = traineeDetail.CourseDurations.Where(x => x.DurationFrom > DateTime.Now).Count();

            return traineeDetail;
        }
    }
}
