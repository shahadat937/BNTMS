using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.TraineeLanguages;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.TraineeLanguages.Requests.Queries 
{ 
    public class GetTraineeLanguageListRequest : IRequest<PagedResult<TraineeLanguageDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
