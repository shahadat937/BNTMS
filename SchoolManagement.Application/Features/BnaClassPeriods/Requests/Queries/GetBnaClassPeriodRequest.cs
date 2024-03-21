using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaClassPeriods.Requests.Queries
{
    public class GetBnaClassPeriodRequest : IRequest<List<SelectedModel>>
    {
        public int BaseSchoolNameId { get; set; }
    }
}
