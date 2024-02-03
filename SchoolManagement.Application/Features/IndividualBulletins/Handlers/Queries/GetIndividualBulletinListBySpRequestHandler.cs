using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Queries
{
    public class GetIndividualBulletinListBySpRequestHandler : IRequestHandler<GetIndividualBulletinListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<Bulletin> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetIndividualBulletinListBySpRequestHandler(ISchoolManagementRepository<Bulletin> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetIndividualBulletinListBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetBulletinForInstructor] {0},{1}", request.BaseSchoolNameId, request.TraineeId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
