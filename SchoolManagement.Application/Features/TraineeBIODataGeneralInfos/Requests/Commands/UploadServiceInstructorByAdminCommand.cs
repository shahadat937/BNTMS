using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Commands
{
    public class UploadServiceInstructorByAdminCommand : IRequest<BaseCommandResponse>
    {
        public IFormFile ServiceInstructorFile { get; set; }
    }
}
