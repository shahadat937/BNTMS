using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Queries;
using SchoolManagement.Application.Models;
using SchoolManagement.Domain;
using System.Data;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Queries
{
    public class GetCourseNomeneeByParametersRequestHandler : IRequestHandler<GetCourseNomeneeByParametersRequest, List<CourseNomeneeDto>>
    {
        private readonly ISchoolManagementRepository<CourseNomenee> _CourseNomeneeRepository;

        private readonly IMapper _mapper;
        public GetCourseNomeneeByParametersRequestHandler(ISchoolManagementRepository<CourseNomenee> CourseNomeneeRepository, IMapper mapper)
        {
            _CourseNomeneeRepository = CourseNomeneeRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseNomeneeDto>> Handle(GetCourseNomeneeByParametersRequest request, CancellationToken cancellationToken)
        {
            IQueryable<CourseNomenee> CourseNomenees = _CourseNomeneeRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.BnaSubjectNameId == request.BnaSubjectNameId  && x.CourseNameId == request.CourseNameId && x.CourseDurationId == request.CourseDurationId && x.CourseSectionId == request.CourseSectionId,"CourseDuration", "BaseSchoolName", "CourseName", "BnaSubjectName", "MarkType", "CourseModule", "Trainee", "Trainee.Rank", "Trainee.SaylorRank").OrderBy(x=>x.Status);
            //var CourseNomenees = _CourseNomeneeRepository.Where(x => x.BaseSchoolNameId == request.BaseSchoolNameId && x.CourseNameId == request.CourseNameId && x.CourseModuleId == request.CourseModuleId && x.Status == request.Status).OrderByDescending(x => x.CourseNomeneeId);

            var CourseNomeneeDtos = _mapper.Map<List<CourseNomeneeDto>>(CourseNomenees);

            return CourseNomeneeDtos;
        }
        
    }
}
