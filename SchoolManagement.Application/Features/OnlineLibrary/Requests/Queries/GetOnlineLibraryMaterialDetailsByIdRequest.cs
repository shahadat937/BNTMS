using MediatR;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Requests.Queries
{
    public class GetOnlineLibraryMaterialDetailsByIdRequest : IRequest <OnlineLibraryDto>
    {
        public int Id { get; set; }
    }
}
