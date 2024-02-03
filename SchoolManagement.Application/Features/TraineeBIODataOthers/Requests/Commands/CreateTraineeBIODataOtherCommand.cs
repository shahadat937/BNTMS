using SchoolManagement.Application.DTOs.TraineeBioDataOther;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeBioDataOthers.Requests.Commands
{
    public class CreateTraineeBioDataOtherCommand : IRequest<BaseCommandResponse>
    {
        public CreateTraineeBioDataOtherDto TraineeBioDataOtherDto { get; set; }

    }
}
