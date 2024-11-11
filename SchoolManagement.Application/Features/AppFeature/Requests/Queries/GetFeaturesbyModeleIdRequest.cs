using MediatR;
using SchoolManagement.Application.DTOs.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.AppFeature.Requests.Queries
{
    public class GetFeaturesbyModeleIdRequest : IRequest<List<FeatureDto>>
    {
        public int ModuleId { get; set; }
    }
}
