using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.CourseNomenees;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Queries
{ 
   public class GetBnaNomeneeSubjectSectionAsignRequest : IRequest<object>
    {
        public int traineeNominationId { get; set; }
}
}
