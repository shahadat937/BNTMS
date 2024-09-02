using MediatR;
using SchoolManagement.Application.Responses;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.DTOs.Bulletin
{
    public class CreateBulletinBulkDto
    {
        public int BulletinId { get; set; }
        public List<SelectedModel>? BaseSchoolNameId { get; set; }
        public List<string>? CourseNameId { get; set; }
        public int? CourseDurationId { get; set; }
        public string? BuletinDetails { get; set; }
        public int? Status { get; set; }
        public int? MenuPosition { get; set; }
        public bool IsActive { get; set; }
    }
}
