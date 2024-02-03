using MediatR;
using SchoolManagement.Application.DTOs.ClassPeriod;
using SchoolManagement.Application.DTOs.TdecQuestionName;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.ClassPeriods.Requests.Queries
{
    public class GetTdecListRequest : IRequest<List<TdecQuestionNameDto>> 
    {
        public int BaseSchoolNameId { get; set; }
    }
} 

  