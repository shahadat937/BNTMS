using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Requests.Commands
{
    public class DeleteSocialMediaTypeCommand : IRequest  
    {   
        public int Id { get; set; }
    }
}
