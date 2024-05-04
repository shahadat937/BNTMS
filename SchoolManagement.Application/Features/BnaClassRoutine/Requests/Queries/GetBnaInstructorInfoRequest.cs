using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassRoutine.Requests.Queries
{
    public class GetBnaInstructorInfoRequest : IRequest<List<BnaInstructorModel>>
    {
        public string bnaSelectedSubjectCurriculumId { get; set; }
        public string selectedCourseNameId { get; set; }
        public string selectedCourseDurationId { get; set; }
        public string selectedBnaSemesterId { get; set; }
        public string selectedCourseSectionId { get; set; }
        public int selectedCourseWeekId { get; set; }
    }
}
