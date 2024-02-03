using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetClassRoutineDetailRequestHandler : IRequestHandler<GetClassRoutineDetailRequest, ClassRoutineDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ClassRoutine> _ClassRoutineRepository;
        public GetClassRoutineDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }
        public async Task<ClassRoutineDto> Handle(GetClassRoutineDetailRequest request, CancellationToken cancellationToken)
        {
            try { 
                var ClassRoutine =  _ClassRoutineRepository.FilterWithInclude(x => x.ClassRoutineId == request.ClassRoutineId, "CourseName", "CourseDuration", "BnaSubjectName");
                return _mapper.Map<ClassRoutineDto>(ClassRoutine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return null;
        }
    }
}
