using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetClassRoutineHeaderByParamsRequestHandler : IRequestHandler<GetClassRoutineHeaderByParamsRequest, object>
    {

        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

        private readonly IMapper _mapper;

        public GetClassRoutineHeaderByParamsRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetClassRoutineHeaderByParamsRequest request, CancellationToken cancellationToken)
        {
            var spQuery = String.Format("exec [spGetRoutineHeaderByParams] {0},{1},{2},{3}", request.BaseSchoolNameId, request.CourseNameId, request.CourseDurationId, request.CourseSectionId);

            DataTable dataTable = _ClassRoutineRepository.ExecWithSqlQuery(spQuery);

            return dataTable;


        }
    }
}
