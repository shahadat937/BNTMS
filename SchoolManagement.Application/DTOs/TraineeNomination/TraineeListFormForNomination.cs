using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public class TraineeListFormForNomination
    {
        public int CourseNomeneeId { get; set; }
        public int? CourseNameId { get; set; }
        public int? Status { get; set; }
        public string? TraineePNo { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; }
        public string? RankPosition { get; set; }
        public string? IndexNo { get; set; }
        public int? CourseSectionId { get; set; }
        public string? PresentBillet { get; set; }
        public int TraineeNominationId { get; set; }
        public int? ExamCenterId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
        public int? CourseDurationId { get; set; }
        public int? ExamAttemptTypeId { get; set; }
        public int? ExamTypeId { get; set; }
        public int? TraineeCourseStatusId { get; set; }
        public int? WithdrawnDocId { get; set; }
        public int? NewAtemptId { get; set; }
        public string? FamilyAllowId { get; set; }
        public int? SaylorRankId { get; set; }
        public int? RankId { get; set; }
        public int? SaylorBranchId { get; set; }
        public int? SaylorSubBranchId { get; set; }
        public int? BranchId { get; set; }
        public string? CertificateSerialNo { get; set; }
        public string? WithdrawnRemarks { get; set; }
        public DateTime? WithdrawnDate { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }


    }
}
