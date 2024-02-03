using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Board;

namespace SchoolManagement.Application.Features.Boards.Requests.Commands
{
    public class UpdateBoardCommand : IRequest<Unit>
    {
        public BoardDto BoardDto { get; set; } 

    }
}
