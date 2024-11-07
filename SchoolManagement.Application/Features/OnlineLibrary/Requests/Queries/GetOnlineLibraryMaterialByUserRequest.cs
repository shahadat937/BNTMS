using MediatR;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using SchoolManagement.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Requests.Queries
{
    public class GetOnlineLibraryMaterialByUserRequest: IRequest<PagedResult<OnlineLibraryDto>>
    {
        public string UserId { get; set; }
        public QueryParams QueryParams { get; set; }
    }
}
