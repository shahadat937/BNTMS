using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Common;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Models;
using System;  
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.SocialMedias.Requests.Queries 
{ 
    public class GetSocialMediaListRequest : IRequest<PagedResult<SocialMediaDto>>
    { 
        public QueryParams QueryParams { get; set; }  
    }
}
