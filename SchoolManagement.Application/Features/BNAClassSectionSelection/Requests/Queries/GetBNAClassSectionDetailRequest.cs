using MediatR; 
using SchoolManagement.Application.DTOs.BnaClassSectionSelection;
using System; 
using System.Collections.Generic;   
using System.Text;  
 
namespace SchoolManagement.Application.Features.BnaClassSections.Requests.Queries
{
    public class GetBnaClassSectionDetailRequest : IRequest<BnaClassSectionSelectionDto>
    {
        public int Id { get; set; }
    }
}
