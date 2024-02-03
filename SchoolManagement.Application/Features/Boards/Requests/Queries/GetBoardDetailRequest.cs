using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Board;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.Boards.Requests.Queries
{
    public class GetBoardDetailRequest : IRequest<BoardDto>
    {
        public int BoardId { get; set; }
    }
}
