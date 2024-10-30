using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.ReadingMaterials.Requests.Queries
{
    public class GetReadingMaterialsForStudentsSpRequest : IRequest<object>
    {
        public int DocumentTypeId { get; set; }
        public int SchoolId { get; set; }
        public int courseId { get; set; }   


    }
}
