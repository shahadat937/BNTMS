using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetTraineeAttendenceListOfCentralExamRequest: IRequest <object>
    {
        public int? CourseDurationId { get; set; }
        public int? AttendanceStatus { get; set; }
        public int? CourseNameId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public int? ClassRoutineId { get; set; }
    }
}
