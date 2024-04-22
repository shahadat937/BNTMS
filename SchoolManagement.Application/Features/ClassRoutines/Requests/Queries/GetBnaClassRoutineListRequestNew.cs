using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetBnaClassRoutineListRequestNew : IRequest<List<BnaRoutineModel>>
    {
        public string bnaSelectedSubjectCurriculumId { get; set; }
        public string selectedCourseNameId { get; set; }
        public string selectedCourseDurationId { get; set; }
        public string selectedBnaSemesterId { get; set; }
        public string selectedCourseSectionId { get; set; }
        public int selectedCourseWeekId { get; set; }
    }
}

