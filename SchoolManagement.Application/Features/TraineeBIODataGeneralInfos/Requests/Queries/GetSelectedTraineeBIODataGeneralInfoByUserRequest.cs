using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetSelectedTraineeBioDataGeneralInfoByUser : IRequest<List<SelectedModel>>
    {
        public string User { get; set; } 
    }
}
