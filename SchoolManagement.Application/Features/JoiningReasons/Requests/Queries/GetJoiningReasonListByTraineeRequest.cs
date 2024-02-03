using SchoolManagement.Application.DTOs.JoiningReasons;
using MediatR;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.JoiningReasons.Requests.Queries
{
    public class GetJoiningReasonListByTraineeRequest : IRequest<List<JoiningReasonDto>>
    {
        public int Traineeid { get; set; }
    } 
}
