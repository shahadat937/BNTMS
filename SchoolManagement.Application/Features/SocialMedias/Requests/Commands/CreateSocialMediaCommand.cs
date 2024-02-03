using MediatR;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using SchoolManagement.Application.DTOs.SocialMedias;

namespace SchoolManagement.Application.Features.SocialMedias.Requests.Commands 
{
    public class CreateSocialMediaCommand : IRequest<BaseCommandResponse> 
    {
        public CreateSocialMediaDto SocialMediaDto { get; set; }      

    }
}
