using SchoolManagement.Application.Responses;
using MediatR; 
using SchoolManagement.Application.DTOs.CourseNomenees;

namespace SchoolManagement.Application.Features.CourseNomenees.Requests.Commands
{


public class CreateCourseNomeneeListCommand : IRequest<BaseCommandResponse>
{
    public CreateCourseListNomeneeDto CourseListNomeneeDto { get; set; }
}
} 
 