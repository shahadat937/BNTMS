using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.TrainingSyllabus;
using SchoolManagement.Application.Features.TrainingSyllabuss.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.TrainingSyllabuses.Handlers.Queries
{
    public class GetTrainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameIdRequestHandler : IRequestHandler<GetTrainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameIdRequest, List<TrainingSyllabusDto>>
    {
        private readonly ISchoolManagementRepository<TrainingSyllabus> _TrainingSyllabusRepository;
        private readonly IMapper _mapper;

        public GetTrainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameIdRequestHandler(ISchoolManagementRepository<TrainingSyllabus> TrainingSyllabusRepository, IMapper mapper)
        {
            _TrainingSyllabusRepository = TrainingSyllabusRepository;
            _mapper = mapper;
        }
         
        public async Task<List<TrainingSyllabusDto>> Handle(GetTrainingSyllabusListBySchoolIdCourseNameIdAndSubjectNameIdRequest request, CancellationToken cancellationToken)
        {
            ICollection<TrainingSyllabus> TrainingSyllabuses = _TrainingSyllabusRepository.FilterWithInclude(x=>x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.BnaSubjectNameId == request.BnaSubjectNameId , "BaseSchoolName", "CourseName", "BnaSubjectName", "CourseTask", "TrainingObjective").ToList();
            
            var TrainingSyllabusDtos = _mapper.Map<List<TrainingSyllabusDto>>(TrainingSyllabuses);
            return TrainingSyllabusDtos; 
        }
    }
}
