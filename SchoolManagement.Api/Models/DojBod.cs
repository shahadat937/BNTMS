using System;
using System.Collections.Generic;

namespace SchoolManagement.Api.Models
{
    public partial class DojBod
    {
        public int DojBodid { get; set; }
        public string Pno { get; set; }
        public string FullName { get; set; }
        public string Branch { get; set; }
        public string Rank { get; set; }
        public string PostingUnitName { get; set; }
        public DateTime? EntryDate { get; set; }
        public DateTime? DateofBirth { get; set; }
        public string Relegion { get; set; }
        public string PresentAddress { get; set; }
        public string NextofKin { get; set; }
        public string FatherName { get; set; }
        public string Nid { get; set; }
        public string Mobile { get; set; }
        public string Sex { get; set; }
        public string Mobile1 { get; set; }
        public string NikName { get; set; }
        public string MotherName { get; set; }
    }
}
