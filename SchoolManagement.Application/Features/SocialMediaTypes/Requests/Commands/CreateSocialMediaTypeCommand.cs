using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.SocialMediaTypes;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Requests.Commands 
{
    public class CreateSocialMediaTypeCommand : IRequest<BaseCommandResponse> 
    {
        public CreateSocialMediaTypeDto SocialMediaTypeDto { get; set; }      

    }
}
