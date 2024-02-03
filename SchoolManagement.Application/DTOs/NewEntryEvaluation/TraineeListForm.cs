using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.NewEntryEvaluation
{
    public class TraineeListForm
    {
        public int? CourseNameId { get; set; }
        public int? Status { get; set; }
        public string? TraineePNo { get; set; }
        public int? TraineeId { get; set; }
        public string? TraineeName { get; set; }
        public string? RankPosition { get; set; }
        public int? TraineeNominationId { get; set; }
        public double? Noitikota { get; set; }
        public double? Utsaho { get; set; }
        public double? Sahonsheelota { get; set; }
        public double? Samayanubartita { get; set; }
        public double? Manovhab { get; set; }
        public double? Udyam { get; set; }
        public double? KhapKhawano { get; set; }
        public double? Onyano { get; set; }
    }
}
