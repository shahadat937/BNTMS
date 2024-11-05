using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.Features.Instructor.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Instructor.Handlers.Queries
{
    public class GetInstructorBySchoolRequestHandler : IRequestHandler<GetInstructorBySchoolRequest, object>
    {
        private readonly IMapper _mapper;
        //private readonly ISchoolManagementRepository<Instructor> _traineeBioDataGeneralInfoRepository;

        public async Task<object> Handle(GetInstructorBySchoolRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
