using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseDurations.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.CourseDurations.Handlers.Queries
{
    public class GetNbcdSchoolNameByCourseDurationIdRequestHandler : IRequestHandler<GetNbcdSchoolNameByCourseDurationIdRequest, object>
    {
        private readonly ISchoolManagementRepository<CourseDuration> _courseDurationRepository;

        private readonly IMapper _mapper;

        public GetNbcdSchoolNameByCourseDurationIdRequestHandler(ISchoolManagementRepository<CourseDuration> courseDurationRepository, IMapper mapper)
        {
            _courseDurationRepository = courseDurationRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetNbcdSchoolNameByCourseDurationIdRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetNbcdSchoolNameByCourseDurationId] {0}", request.CourseDurationId);
            
            DataTable dataTable = _courseDurationRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
