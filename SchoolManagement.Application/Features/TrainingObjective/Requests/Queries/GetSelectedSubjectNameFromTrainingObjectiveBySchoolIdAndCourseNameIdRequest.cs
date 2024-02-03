using MediatR;
using SchoolManagement.Shared.Models;

namespace SchoolManagement.Application.Features.TrainingObjectives.Requests.Queries
{
    public class GetSelectedSubjectNameFromTrainingObjectiveBySchoolIdAndCourseNameIdRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; } 
        public int CourseNameId { get; set; } 
    }
}   
   