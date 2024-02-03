namespace SchoolManagement.Application.DTOs.Attendance
{
    public class CreateAttendanceListDtoInstructor
    {
        public int AttendanceId { get; set; }
        public int? BaseSchoolNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? ClassRoutineId { get; set; }
        public int? ClassPeriodIds { get; set; }
        public int? CourseSectionId { get; set; }
        public int? BnaSubjectNameId { get; set; }
        public DateTime AttendanceDate { get; set; }
        public List<TraineeListDtoInstructor> TraineeListForm { get; set; }
    }
}
