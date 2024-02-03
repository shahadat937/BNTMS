using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SocialMedias.Requests.Commands
{
    public class DeleteSocialMediaCommand : IRequest  
    {  
        public int Id { get; set; }
    }
}
