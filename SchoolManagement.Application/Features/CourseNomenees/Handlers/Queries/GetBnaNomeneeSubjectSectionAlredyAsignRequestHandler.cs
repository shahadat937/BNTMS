using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Models;
using MediatR;
using AutoMapper;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.Common.Validators;
using SchoolManagement.Application.Exceptions;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Domain;
using SchoolManagement.Application.Features.CourseNomenees.Requests.Queries;
using SchoolManagement.Application.Features.TraineeAssessmentMarks.Requests.Queries;
using System.Data;
using SchoolManagement.Shared.Models;
using System.Net.Sockets;

namespace SchoolManagement.Application.Features.CourseNomenees.Handlers.Queries
{
    public class GetBnaNomeneeSubjectSectionAlredyAsignRequestHandler : IRequestHandler<GetBnaNomeneeSubjectSectionAlredyAsignRequest, object>
    {

        private readonly ISchoolManagementRepository<CourseNomenee> _CourseNomeneeRepository;
        private readonly ISchoolManagementRepository<CourseSection> _CourseSectionRepository;
        private readonly ISchoolManagementRepository<BnaSubjectName> _BnaSubjectNameRepository;

        private readonly IMapper _mapper;

        public GetBnaNomeneeSubjectSectionAlredyAsignRequestHandler(ISchoolManagementRepository<CourseNomenee> CourseNomeneeRepository, ISchoolManagementRepository<CourseSection> CourseSectionRepository, ISchoolManagementRepository<BnaSubjectName> BnaSubjectNameRepository, IMapper mapper)
        {
            _CourseNomeneeRepository = CourseNomeneeRepository;
            _BnaSubjectNameRepository = BnaSubjectNameRepository;
            _CourseSectionRepository = CourseSectionRepository;
            _mapper = mapper;
        }

        public async Task<object> Handle(GetBnaNomeneeSubjectSectionAlredyAsignRequest request, CancellationToken cancellationToken)
        {
            List<CourseNomeneeModel> courseNomeneeModel = new List<CourseNomeneeModel>();
            IQueryable<CourseNomenee> bnaClassRoutiness = _CourseNomeneeRepository.Where(x => x.TraineeNominationId == request.traineeNominationId);

            foreach (var item in bnaClassRoutiness)
            {
                var subjectName = _BnaSubjectNameRepository.Where(x => x.BnaSubjectNameId == item.BnaSubjectNameId).Select(x => x.SubjectName).FirstOrDefault();
                var courseSectionName = _CourseSectionRepository.Where(x => x.CourseSectionId == item.CourseSectionId).Select(x => x.SectionName).FirstOrDefault();
                CourseNomeneeModel courseModel = new CourseNomeneeModel
                {
                    SubjectName = subjectName,
                    SubjectId = item.BnaSubjectNameId,
                    CourseSectionId = item.CourseSectionId,
                    CourseSectionName = courseSectionName
                };
                courseNomeneeModel.Add(courseModel);
            }
            return courseNomeneeModel;
        }
        public class CourseNomeneeModel
        {
            public object SubjectName { get; set; }
            public object SubjectId { get; set; }
            public object CourseSectionName { get; set; }
            public object CourseSectionId { get; set; }
        }
    }
}
