using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Requests.Commands
{
    public class DeleteOnlineLibraryMaterialRequest : IRequest
    {
        public int OnlineLibraryId { get; set; }
    }
}
