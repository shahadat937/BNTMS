using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReadingMaterials.Handlers.Queries
{
    public class GetReadingMaterialsForStudentsSpRequestHandler : IRequestHandler<GetReadingMaterialsForStudentsSpRequest, object>
    {
        private readonly ISchoolManagementRepository<ReadingMaterial> _studentInfoByTraineeIdRepository;

        private readonly IMapper _mapper;
        public GetReadingMaterialsForStudentsSpRequestHandler(ISchoolManagementRepository<ReadingMaterial> studentInfoByTraineeIdRepository, IMapper mapper)
        {
            _studentInfoByTraineeIdRepository = studentInfoByTraineeIdRepository;
            _mapper = mapper;

        }
        public async Task<object> Handle(GetReadingMaterialsForStudentsSpRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetReadingMaterialsForStudents] {0}, {1}, {2}", request.DocumentTypeId, request.SchoolId, request.courseId);

            DataTable dataTable = _studentInfoByTraineeIdRepository.ExecWithSqlQuery(spQuery);

            return dataTable;
        }
    }
}
