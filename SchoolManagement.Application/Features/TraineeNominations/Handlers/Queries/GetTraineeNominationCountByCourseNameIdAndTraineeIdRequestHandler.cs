using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Application.Features.TraineeNominations.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Handlers.Queries   
{
    public class GetTraineeNominationCountByCourseNameIdAndTraineeIdRequestHandler : IRequestHandler<GetTraineeNominationCountByCourseNameIdAndTraineeIdRequest, int>
    {
        private readonly ISchoolManagementRepository<TraineeNomination> _TraineeNominationRepository;

            
        public GetTraineeNominationCountByCourseNameIdAndTraineeIdRequestHandler(ISchoolManagementRepository<TraineeNomination> TraineeNominationRepository)
        {
            _TraineeNominationRepository = TraineeNominationRepository;    
        }

        public async Task<int> Handle(GetTraineeNominationCountByCourseNameIdAndTraineeIdRequest request, CancellationToken cancellationToken)
        {
            var TraineeNominations = _TraineeNominationRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId && x.CourseNameId == request.CourseNameId);
           
            var nominationCount = TraineeNominations.Count();
           
            return nominationCount;
        }
    }
}
