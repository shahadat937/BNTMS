using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Queries
{
    public class GetIndividualBulletinByDurationRequestHandler : IRequestHandler<GetIndividualBulletinByDurationRequest, object>
    {

        private readonly ISchoolManagementRepository<IndividualBulletin> _IndividualBulletinRepository;

        private readonly IMapper _mapper;

        public GetIndividualBulletinByDurationRequestHandler(ISchoolManagementRepository<IndividualBulletin> IndividualBulletinRepository, IMapper mapper)
        {
            _IndividualBulletinRepository = IndividualBulletinRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetIndividualBulletinByDurationRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetBulletinByDuration] {0}, {1}, {2}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId);
            
            DataTable dataTable = _IndividualBulletinRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
