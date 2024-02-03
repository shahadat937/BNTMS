using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.Branch;
using SchoolManagement.Application.DTOs.Complexion;
using SchoolManagement.Application.DTOs.EducationalInstitutions;
using SchoolManagement.Application.DTOs.Height;
using SchoolManagement.Application.Features.Branchs.Requests.Queries;
using SchoolManagement.Application.Features.Complexions.Requests.Queries;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Queries;
using SchoolManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Handlers.Queries
{  
    public class GetEducationalInstitutionDetailRequestHandler : IRequestHandler<GetEducationalInstitutionDetailRequest, EducationalInstitutionDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<EducationalInstitution> _EducationalInstitutionRepository;       
        public GetEducationalInstitutionDetailRequestHandler(ISchoolManagementRepository<EducationalInstitution> EducationalInstitutionRepository, IMapper mapper)
        {
            _EducationalInstitutionRepository = EducationalInstitutionRepository;    
            _mapper = mapper; 
        } 
        public async Task<EducationalInstitutionDto> Handle(GetEducationalInstitutionDetailRequest request, CancellationToken cancellationToken)
        {
            var EducationalInstitution = await _EducationalInstitutionRepository.FindOneAsync(x => x.EducationalInstitutionId == request.EducationalInstitutionId, "District", "Thana");    
            return _mapper.Map<EducationalInstitutionDto>(EducationalInstitution);    
        }
    }
}
