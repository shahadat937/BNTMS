using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public interface ITraineeNominationDto
    {

        public int TraineeNominationId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? CourseNameId { get; set; }
        public int? DepartmentId { get; set; }
        public int? BnaSubjectCurriculumId { get; set; }
        public int? ExamAttemptTypeId { get; set; }
        public int? ExamTypeId { get; set; }
        public int? TraineeId { get; set; }
        public int? CourseAttendState { get; set; }
        public string? CertificateSerialNo { get; set; }
        public string? CourseAttendStateRemark { get; set; }
        public int? ExamCenterId { get; set; }
        public int? CourseSectionId { get; set; }
        public int? NewAtemptId { get; set; }
        public int? SaylorRankId { get; set; }
        public int? RankId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? BranchId { get; set; }
        public string? IndexNo { get; set; }
        public string? FamilyAllowId { get; set; }
        public int? TraineeCourseStatusId { get; set; }
        public int? WithdrawnDocId { get; set; }
        public string? PresentBillet { get; set; }
        public string? WithdrawnRemarks { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


    }
}
