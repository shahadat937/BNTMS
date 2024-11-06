using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.DTOs.OnlineLibrary
{
    public interface IOnlineLibraryDto
    {

        public int OnlineLibraryId { get; set; }     
        public int? BaseSchoolNameId { get; set; }
        public int? DocumentTypeId { get; set; }
        public int? ShowRightId { get; set; }
        public int? DownloadRightId { get; set; }
        public string? DocumentName { get; set; }
        public string? DocumentLink { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public string? ApprovedUser { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
        public string? AurhorName { get; set; }
        public string? PublisherName { get; set; }


    }
}
