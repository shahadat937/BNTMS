using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Domain;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetInstructorAvailabilityByDateAndPeriodRequestHandler : IRequestHandler<GetInstructorAvailabilityByDateAndPeriodRequest, List<ClassRoutineDto>>
    {
        private readonly ISchoolManagementRepository<ClassRoutine> _classRoutineRepository;
        private readonly IMapper _mapper;

        public GetInstructorAvailabilityByDateAndPeriodRequestHandler(ISchoolManagementRepository<ClassRoutine> classRoutineRepository, IMapper mapper)
        {
            _classRoutineRepository = classRoutineRepository;
            _mapper = mapper;
        }

        public async Task<List<ClassRoutineDto>> Handle(GetInstructorAvailabilityByDateAndPeriodRequest request, CancellationToken cancellationToken)
        {
            IQueryable<ClassRoutine> classRoutines = _classRoutineRepository.FilterWithInclude(x => x.TraineeId == request.TraineeId && x.ClassPeriodId == request.ClassPeriodId && (!x.Date.HasValue || x.Date.Value.Date == request.Date), "ClassPeriod", "BaseSchoolName", "CourseName", "CourseDuration", "BnaSubjectName", "ClassType", "CourseModule", "CourseSection");
            var ClassRoutineDtos = _mapper.Map<List<ClassRoutineDto>>(classRoutines);
            //List<SelectedModel> selectModels = classRoutines.Select(x => new SelectedModel 
            //{
            //    Text = x.BnaSubjectName.SubjectName,
            //    Value = x.BnaSubjectNameId 
            //}).ToList();
            return ClassRoutineDtos;
        }
    }
}
