using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetRunningCivilTraineeRequest : IRequest<object>
    {
        public string? SearchText { get; set; }
    }
}
