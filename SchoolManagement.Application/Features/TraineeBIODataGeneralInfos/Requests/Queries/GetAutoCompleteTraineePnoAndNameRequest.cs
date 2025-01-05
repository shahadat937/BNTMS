using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetAutoCompleteTraineePnoAndName : IRequest<List<SelectedModel>>
    {
        public string PNo { get; set; }
    
    }
}
 