namespace SchoolManagement.Application.DTOs.MigrationDocument
{
    public class MigrationDocumentDto : IMigrationDocumentDto 
    {
        public int MigrationDocumentId { get; set; }
        public int? CourseDurationId { get; set; }
        public int? TraineeNominationId { get; set; }
        public int? TraineeId { get; set; }
        public int? RelationTypeId { get; set; }
        public string? RelationType { get; set; }
        public string? Remarks { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }

    }
}

