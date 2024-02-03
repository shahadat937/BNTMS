using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ForeignCourseOtherDocs.Requests.Queries
{
    public class GetSelectedForeignCourseOtherDocRequest : IRequest<List<SelectedModel>>
    {
    }
}
