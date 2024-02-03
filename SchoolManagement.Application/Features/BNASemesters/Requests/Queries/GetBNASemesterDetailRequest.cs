using MediatR;
using SchoolManagement.Application.DTOs.BnaSemester;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.BnaSemesters.Requests.Queries
{
    public class GetBnaSemesterDetailRequest: IRequest<BnaSemesterDto>
    {
        public int BnaSemesterId { get; set; }
    }
}
 