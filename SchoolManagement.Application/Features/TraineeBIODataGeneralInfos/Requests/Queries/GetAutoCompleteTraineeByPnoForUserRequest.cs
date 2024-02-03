using MediatR;
using SchoolManagement.Shared.Models;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.TraineeBioDataGeneralInfos.Requests.Queries
{
    public class GetAutoCompleteTraineeByPnoForUserRequest : IRequest<List<SelectedModel>>
    {
        public string Pno { get; set; }
    }
}
 