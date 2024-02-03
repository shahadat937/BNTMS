using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.DTOs.Board;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.Models;

namespace SchoolManagement.Application.Features.Boards.Requests.Queries
{
    public class GetBoardListRequest : IRequest<PagedResult<BoardDto>>
    {
        public QueryParams QueryParams { get; set; }
    }
}
