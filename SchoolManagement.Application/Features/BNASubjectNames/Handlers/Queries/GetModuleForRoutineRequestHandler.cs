using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Application.Features.BnaSubjectNames.Requests.Queries;
using SchoolManagement.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaSubjectNames.Handlers.Queries
{  
    public class GetModuleForRoutineRequestHandler : IRequestHandler<GetModuleForRoutineRequest, int?>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;       
        public GetModuleForRoutineRequestHandler(ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _BnaSubjectNameRepository = BnaSubjectNameRepository;    
            _mapper = mapper; 
        } 
        public async Task<int?> Handle(GetModuleForRoutineRequest request, CancellationToken cancellationToken)
        {
            //var BnaSubjectName = await _BnaSubjectNameRepository.Get(request.Id);
             var BnaSubjectName = _BnaSubjectNameRepository.FinedOneInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId);
            return BnaSubjectName.CourseModuleId;
            //return _mapper.Map<BnaSubjectNameDto>(ModuleId);    
        }

        //public async Task<int> Handle(GetSelectedRoutineIdWithSchoolCourseSubjectRequest request, CancellationToken cancellationToken)
        //{
        //    var classRoutines = _classRoutineRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId && x.ClassTypeId == 4).FirstOrDefault();
        //    return classRoutines.ClassRoutineId;
        //}
    }
}
