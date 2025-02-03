using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.TraineeNominations.Requests.Queries
{
    public class GetRunningTraineeByTraineeStatusRequest : IRequest<object>
    {
        public int TraineeStatusId { get; set; }
        public int? OfficerTypeId { get; set; }
        public string? SearchText { get; set; }
    }
}
