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

namespace SchoolManagement.Application.Features.GlobalSearch.Handlers.Queries
{
    public class GetSearchedTraineeDetailRequestHandler: IRequestHandler<GetSearchedTraineeDetailRequest,object>
    {
        private readonly ISchoolManagementRepository<Domain.CourseDuration> _CourseDurationRepo;
        private readonly ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> _TraineeInfoRepo;
        private readonly ISchoolManagementRepository<Domain.TraineeNomination> _TraineeNominationRepo;
        private readonly IMapper _mapper;
        public GetSearchedTraineeDetailRequestHandler(ISchoolManagementRepository<Domain.CourseDuration> CourseDurationRepo,
            ISchoolManagementRepository<Domain.TraineeBioDataGeneralInfo> TraineeInfoRepo,
            ISchoolManagementRepository<Domain.TraineeNomination> TraineeNominationRepo,
            IMapper mapper)
        {
            _CourseDurationRepo = CourseDurationRepo;
            _TraineeInfoRepo = TraineeInfoRepo;
            _TraineeNominationRepo = TraineeNominationRepo;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetSearchedTraineeDetailRequest request, CancellationToken cancellationToken)
        {
            // TODO: YET TO IMPLEMENT
            var trainee = _CourseDurationRepo.Get(request.TraineeId);

            if(trainee == null)
            {
                throw new NotFoundException(nameof(trainee), request.TraineeId);
            }

            var traineeDetail = new SearchedTraineeDetailDto();

            List<int?> courseDurationIds = await _TraineeNominationRepo.Where(x => x.TraineeId == request.TraineeId && x.TraineeId != null).Select(x =>x.CourseDurationId).Distinct().ToListAsync();

            var courseDurations = _CourseDurationRepo.Where(x => courseDurationIds.Contains(x.CourseDurationId)).Distinct().ToListAsync();

            traineeDetail.CourseDurations = _mapper.Map<List<CourseDurationDto>>(courseDurations);

            return traineeDetail;
        }
    }
}
