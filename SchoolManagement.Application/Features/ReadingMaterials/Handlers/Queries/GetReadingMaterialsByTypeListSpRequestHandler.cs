using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialsByTypeListSpRequestHandler : IRequestHandler<GetReadingMaterialsByTypeListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ReadingMaterial> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetReadingMaterialsByTypeListSpRequestHandler(ISchoolManagementRepository<ReadingMaterial> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetReadingMaterialsByTypeListSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetReadingMaterialsByType] {0}, {1}", request.DocumentTypeId , request.SchoolId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
