using MediatR;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Requests.Commands
{
    public class UpdateOnlineLibraryRequest : IRequest <Unit>
    {
        public CreateOnlineLibraryDto CreateOnlineLibraryDto { get; set; }
    }
}
