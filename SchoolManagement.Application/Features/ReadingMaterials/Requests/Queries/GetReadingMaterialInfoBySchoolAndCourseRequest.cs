using MediatR;
using SchoolManagement.Application.DTOs.ReadingMaterial;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialInfoBySchoolAndCourseRequest : IRequest<List<ReadingMaterialDto>>
    {
        public int BaseSchoolNameId { get; set; }
        public int CourseNameId { get; set; }
    }
}
