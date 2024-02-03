using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.SocialMedias.Requests.Queries
{
    public class GetSocialMediaDetailRequest : IRequest<SocialMediaDto> 
    {
        public int Id { get; set; } 
    }
}
