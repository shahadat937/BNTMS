using SchoolManagement.Application.DTOs.EducationalQualification;
using MediatR;
using System.Collections.Generic;

namespace SchoolManagement.Application.Features.EducationalQualifications.Requests.Queries
{
    public class GetEducationalQualificationListByTraineeRequest : IRequest<List<EducationalQualificationDto>>
    {
        public int Traineeid { get; set; }
    }
}
