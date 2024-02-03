using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetAutoCompletePnoForFamilyInfoRequest : IRequest<List<SelectedModel>>
    {
        public string Pno { get; set; }
    }
}
 