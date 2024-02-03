using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialByTypeListSpRequestHandler : IRequestHandler<GetReadingMaterialByTypeListSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ReadingMaterial> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetReadingMaterialByTypeListSpRequestHandler(ISchoolManagementRepository<ReadingMaterial> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetReadingMaterialByTypeListSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetReadingMaterialByType] {0}", request.DocumentTypeId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
