using System;

namespace SchoolManagement.Application.DTOs.BnaCurriculumUpdate
{
    public class BnaCurriculumUpdateDto : IBnaCurriculumUpdateDto
    {
        public int BnaCurriculumUpdateId { get; set; }
        public int BnaBatchId { get; set; }
        public int BnaSemesterId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? BnaCurriculumTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


        public string? BnaBatch { get; set; }
        public string? BnaCurriculumType { get; set; }
        public string? BnaSemester { get; set; }
        public string? BnaSemesterDuration { get; set; }
        public string? Trainee { get; set; }

    }
}
