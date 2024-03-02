using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.SubjectMarks.Requests.Queries
{
    public class GetDropdownMarkTypeRequest : IRequest<List<SelectedModel>>
    {
        public int BnaSubjectNameId { get; set; }
    }
}
