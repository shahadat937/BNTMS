using MediatR;
using Microsoft.AspNetCore.Http;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Commands
{
    public class UploadTraineeNominationFileCommand : IRequest<BaseCommandResponse>
    {
        public IFormFile TraineeNominationFile { get; set; }
        public int CourseDurationId { get; set; }
        public int CourseNameId { get; set; }
    }
}
