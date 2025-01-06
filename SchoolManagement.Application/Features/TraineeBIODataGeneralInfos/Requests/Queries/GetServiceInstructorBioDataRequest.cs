using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.TraineeBioDataGeneralInfo;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetServiceInstructorBioDataRequest : IRequest<object>
    {
        public QueryParams QueryParams { get; set; }
        public string? BranchId { get; set; }
    }
}
