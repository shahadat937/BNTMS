using MediatR;
using SchoolManagement.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolManagement.Application.Features.SocialMediaTypes.Requests.Queries
{
    public class GetSelectedSocialMediaTypeRequest : IRequest<List<SelectedModel>> 
    {
    }
}
