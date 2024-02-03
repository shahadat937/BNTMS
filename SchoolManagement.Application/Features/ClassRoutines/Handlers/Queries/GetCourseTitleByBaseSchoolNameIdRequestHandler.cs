//using MediatR;
//using SchoolManagement.Application.Contracts.Persistence;
//using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
//using SchoolManagement.Domain;
//using SchoolManagement.Shared.Models;

//namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
//{
//    public class GetCourseTitleByBaseSchoolNameIdRequestHandler : IRequestHandler<GetCourseTitleByBaseSchoolNameIdRequest, List<SelectedModel>>
//    {
//        private readonly ISchoolManagementRepository<ClassRoutine> _ClassRoutineRepository;

         
//        public GetCourseTitleByBaseSchoolNameIdRequestHandler(ISchoolManagementRepository<ClassRoutine> ClassRoutineRepository)
//        {
//            _ClassRoutineRepository = ClassRoutineRepository;           
//        }

//        public async Task<List<SelectedModel>> Handle(GetCourseTitleByBaseSchoolNameIdRequest request, CancellationToken cancellationToken)
//        {
//            ICollection<ClassRoutine> ClassRoutines = await _ClassRoutineRepository.FilterAsync(x =>x.CourseDurationId == request.CourseDurationId);
//            List<SelectedModel> selectModels = ClassRoutines.Select(x => new SelectedModel
//            {
//                Text = x.Date,
//                Value = x.ClassRoutineId
//            }).ToList();
//            return selectModels;
//        }
//    }
//}
