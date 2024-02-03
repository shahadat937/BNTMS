using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.ReadingMaterialTitles.Requests.Commands
{
    public class DeleteReadingMaterialTitleCommand : IRequest
    {
        public int ReadingMaterialTitleId { get; set; }
    }
}
 