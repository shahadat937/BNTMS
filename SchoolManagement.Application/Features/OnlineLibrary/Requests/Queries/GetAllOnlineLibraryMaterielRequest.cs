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
    public class GetAllOnlineLibraryMaterielRequest : IRequest<PagedResult<OnlineLibraryDto>>
    {
        public QueryParams QueryParams { get; set; }

    }
}
