using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.MilitaryTraining;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.MilitaryTrainings.Requests.Queries
{
    public class GetMilitaryTrainingListRequest : IRequest<PagedResult<MilitaryTrainingDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
