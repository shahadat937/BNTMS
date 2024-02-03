using SchoolManagement.Application.DTOs.SocialMedias;
using MediatR;
using System.Collections.Generic;
using SchoolManagement.Application.DTOs.CodeValues;

namespace SchoolManagement.Application.Features.SocialMedias.Requests.Queries
{
    public class GetSocialMediaListByTraineeRequest : IRequest<List<SocialMediaDto>>
    {
        public int Traineeid { get; set; }
    } 
}
