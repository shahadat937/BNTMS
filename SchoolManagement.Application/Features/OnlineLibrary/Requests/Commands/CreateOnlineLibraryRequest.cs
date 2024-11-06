using MediatR;
using SchoolManagement.Application.DTOs.OnlineLibrary;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.OnlineLibrary.Requests.Commands
{
    public class CreateOnlineLibraryRequest : IRequest<BaseCommandResponse>
    {
        public CreateOnlineLibraryDto OnlineLibraryDto { get; set; }
    }
}
