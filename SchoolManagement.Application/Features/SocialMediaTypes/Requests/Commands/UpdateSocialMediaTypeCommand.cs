using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.SocialMediaTypes;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Requests.Commands
{
    public class UpdateSocialMediaTypeCommand : IRequest<Unit>  
    { 
        public SocialMediaTypeDto SocialMediaTypeDto { get; set; }     
    }
}
