using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.TraineeNomination
{
    public class TraineeListForms
    {
        public int? courseNameId { get; set; }
        public int? status { get; set; }
        public string? traineePNo { get; set; }
        public int? courseDurationId { get; set; }
        public object? presentBillet { get; set; }
        public object? examCenterId { get; set; }
        public DateTime? dateCreated { get; set; }
        public string? createdBy { get; set; }
        public int? traineeId { get; set; }
        public string? traineeName { get; set; }
        public string? rankPosition { get; set; }
        public object? saylorRank { get; set; }
        public object? indexNo { get; set; }
        public int traineeNominationId { get; set; }
        public int? courseSectionId { get; set; }
        public object? examAttemptTypeId { get; set; }
        public object? examTypeId { get; set; }
        public object? familyAllowId { get; set; }
        public object? traineeCourseStatusId { get; set; }
        public object? withdrawnDocId { get; set; }
        public string? withdrawnRemarks { get; set; }
        public DateTime? withdrawnDate { get; set; }
        public object? newAtemptId { get; set; }
        public object? menuPosition { get; set; }
        public int? withdrawnType { get; set; }
    }
}
