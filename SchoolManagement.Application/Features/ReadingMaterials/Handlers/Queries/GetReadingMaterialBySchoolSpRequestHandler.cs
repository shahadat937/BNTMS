using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialBySchoolSpRequestHandler : IRequestHandler<GetReadingMaterialBySchoolSpRequest, object>
    {

        private readonly ISchoolManagementRepository<ReadingMaterial> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;

        public GetReadingMaterialBySchoolSpRequestHandler(ISchoolManagementRepository<ReadingMaterial> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetReadingMaterialBySchoolSpRequest request, CancellationToken cancellationToken)
        {
           // object obj = new object();
            var spQuery = String.Format("exec [spGetReadingMaterialBySchool] {0}", request.BaseSchoolNameId);
            
            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);
           
            return dataTable;
         
        }
    }
}
