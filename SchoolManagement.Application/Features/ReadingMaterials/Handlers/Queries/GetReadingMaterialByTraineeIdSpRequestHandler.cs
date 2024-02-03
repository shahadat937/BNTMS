using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialByTraineeIdSpRequestHandler : IRequestHandler<GetReadingMaterialByTraineeIdSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ReadingMaterial> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetReadingMaterialByTraineeIdSpRequestHandler(ISchoolManagementRepository<ReadingMaterial> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetReadingMaterialByTraineeIdSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetReadingMaterialByTraineeId] {0}", request.BaseSchoolNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
