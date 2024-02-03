using System;

namespace SchoolManagement.Application.DTOs.TraineePicture
{
    public interface ITraineePictureDto
    {
        public int TraineePictureId { get; set; }
        public int? BnaSemesterDurationId { get; set; }
        public int? TraineeId { get; set; }
        public int? BnaSemesterId { get; set; }
        public int? BnaBatchId { get; set; }
        public string? ImageLink { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
