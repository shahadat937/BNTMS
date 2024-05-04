using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassAttendance.Request.Queries
{
    public class GetBnaAttendanceQueryListRequest : IRequest<List<BnaAttendanceModel>>
    {
        public int BnaSubjectCurriculamId { get; set; }
        public int BaseSchoolNameId { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseNameId { get; set; }
        public int SemesterId { get; set; }
        public int CourseSectionId { get; set; }
        public int ClassPeriodId { get; set; }
        public string Date { get; set; }
    }
}
