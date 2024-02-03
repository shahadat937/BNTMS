using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.SocialMedias;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.SocialMedias.Requests.Commands
{
    public class UpdateSocialMediaCommand : IRequest<Unit>  
    { 
        public SocialMediaDto SocialMediaDto { get; set; }     
    }
}
