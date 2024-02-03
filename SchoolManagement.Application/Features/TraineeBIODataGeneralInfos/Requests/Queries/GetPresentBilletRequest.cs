using MediatR;
using SchoolManagement.Application.DTOs.BnaSubjectName;
using SchoolManagement.Shared.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeBIODataGeneralInfos.Requests.Queries
{
    public class GetPresentBilletRequest : IRequest<List<SelectedModel>>
    {
        public int TraineeId { get; set; }
    }
}
 
 