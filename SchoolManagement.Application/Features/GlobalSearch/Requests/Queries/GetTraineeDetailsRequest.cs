using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.GlobalSearch.Requests.Queries
{
    public class GetTraineeDetailsRequest: IRequest<object>
    {
        public int TraineeId { get; set; }
    }
}
