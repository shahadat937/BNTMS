using MediatR;
using SchoolManagement.Application.DTOs.ClassRoutine;
using SchoolManagement.Application.DTOs.ReadingMaterial;

namespace SchoolManagement.Application.Features.ClassRoutines.Requests.Queries
{
    public class GetReadingMaterialsByMaterialTitleIdBaseSchoolIdAndCourseNameIdRequest : IRequest<List<ReadingMaterialDto>>
    {
        public int BaseSchoolNameId { get; set; }  
        public int CourseNameId { get; set; }
        public int ReadingMaterialTitleId { get; set; }
    }
}

 