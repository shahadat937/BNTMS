using SchoolManagement.Application.DTOs.RecordOfService;
using MediatR;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.RecordOfServices.Requests.Queries
{
    public class GetRecordOfServiceListByTraineeRequest : IRequest<List<RecordOfServiceDto>>
    {
        public int Traineeid { get; set; }
    } 
}
