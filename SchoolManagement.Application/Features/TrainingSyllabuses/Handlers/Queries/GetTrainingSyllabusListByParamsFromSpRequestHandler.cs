using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using AutoMapper;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries;
using System.Data;

namespace SchoolManagement.Application.Features.TrainingSyllabuss.Handlers.Queries
{
    public class GetTrainingSyllabusListByParamsFromSpRequestHandler : IRequestHandler<GetTrainingSyllabusListByParamsFromSpRequest, object>
    {

        private readonly ISchoolManagementRepository<TrainingSyllabus> _trainingSyllabusRepository;

        private readonly IMapper _mapper;

        public GetTrainingSyllabusListByParamsFromSpRequestHandler(ISchoolManagementRepository<TrainingSyllabus> trainingSyllabusRepository, IMapper mapper)
        {
            _trainingSyllabusRepository = trainingSyllabusRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetTrainingSyllabusListByParamsFromSpRequest request, CancellationToken cancellationToken)
        {
            
            var spQuery = String.Format("exec [spGetCourseSyllabus] {0},{1},{2}", request.BaseSchoolNameId, request.CourseNameId, request.BnaSubjectNameId);
            
            DataTable dataTable = _trainingSyllabusRepository.ExecWithSqlQuery(spQuery);
            return dataTable;
         
        }
    }
}
