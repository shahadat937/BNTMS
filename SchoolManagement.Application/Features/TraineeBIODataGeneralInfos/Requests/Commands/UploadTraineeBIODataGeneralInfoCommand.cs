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
    public class UploadTraineeBIODataGeneralInfoCommand : IRequest<BaseCommandResponse>
    {
        public IFormFile TraineeBIODataGeneralInfoFile { get; set; }
        public int? TraineeStatusId { get; set; }
        public int? officerTypeId { get; set; }
    }
}
