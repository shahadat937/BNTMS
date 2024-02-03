using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.SocialMediaTypes;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Models;
using System; 
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Requests.Queries 
{ 
    public class GetSocialMediaTypeListRequest : IRequest<PagedResult<SocialMediaTypeDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
