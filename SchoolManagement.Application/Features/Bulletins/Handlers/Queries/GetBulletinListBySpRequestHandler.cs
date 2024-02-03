using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.Bulletins.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.Bulletins.Handlers.Queries
{
    public class GetBulletinListBySpRequestHandler : IRequestHandler<GetBulletinListBySpRequest, object>
    {

        private readonly ISchoolManagementRepository<Bulletin> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetBulletinListBySpRequestHandler(ISchoolManagementRepository<Bulletin> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBulletinListBySpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetBulletin] {0}", request.BaseSchoolNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
