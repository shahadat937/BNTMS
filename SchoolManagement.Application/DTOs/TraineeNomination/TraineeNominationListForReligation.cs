using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public class TraineeNominationListForReligation
    {
        public int attendanceId { get; set; }
        public string? baseSchoolNameId { get; set; }
        public string? courseNameId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public string? courseNameIds { get; set; }
        public string? courseDurationId { get; set; }
        public string? classPeriodId { get; set; }
        public object? attendanceDate { get; set; }
        public string? classLeaderName { get; set; }
        public string? indexNo { get; set; }
        public bool attendanceStatus { get; set; }
        public List<TraineeListForms> traineeListForms { get; set; }
    }
}
