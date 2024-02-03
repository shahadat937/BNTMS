using SchoolManagement.Application.DTOs.Board;
using SchoolManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Boards.Requests.Commands
{
    public class CreateBoardCommand : IRequest<BaseCommandResponse>
    {
        public CreateBoardDto BoardDto { get; set; }

    }
}
