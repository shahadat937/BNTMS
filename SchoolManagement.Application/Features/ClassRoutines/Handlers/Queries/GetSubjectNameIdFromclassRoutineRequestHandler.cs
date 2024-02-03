using AutoMapper;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.Features.ClassRoutines.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Handlers.Queries
{
    public class GetSubjectNameIdFromclassRoutineRequestHandler : IRequestHandler<GetSubjectNameIdFromclassRoutineRequest, int>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.ClassRoutine> _ClassRoutineRepository;
        public GetSubjectNameIdFromclassRoutineRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.ClassRoutine> ClassRoutineRepository, IMapper mapper)
        {
            _ClassRoutineRepository = ClassRoutineRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(GetSubjectNameIdFromclassRoutineRequest request, CancellationToken cancellationToken)
        {
            //try { 
                //var ClassRoutine =  _ClassRoutineRepository.FilterWithInclude(x => x.ClassRoutineId == request.ClassRoutineId, "CourseName", "CourseDuration", "BnaSubjectName");
                var ClassRoutine = await _ClassRoutineRepository.Get(request.ClassRoutineId);
                return (int)ClassRoutine.BnaSubjectNameId;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
            //return null;
        }
    }
}
