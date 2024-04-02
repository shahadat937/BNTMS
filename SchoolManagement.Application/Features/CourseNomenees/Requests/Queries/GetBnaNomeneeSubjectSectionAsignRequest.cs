using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Queries
{ 
   public class GetBnaNomeneeSubjectSectionAsignRequest : IRequest<object>
    {
        public int traineeNominationId { get; set; }
        public int schollNameId { get; set; }
        public int courseNameId { get; set; }
        public int bnaSubjectCurriculumId { get; set; }
        public int bnaSemesterId { get; set; }
}
}
