using AutoMapper;
using SchoolManagement.Application.DTOs.EducationalInstitutions;
using SchoolManagement.Application.Features.EducationalInstitutions.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.EducationalInstitutions.Handlers.Queries
{
    //public class GetEducationalInstitutionListByTraineeRequestHandler : IRequestHandler<GetEducationalInstitutionListByTraineeRequest, Unit>


    public class GetEducationalInstitutionListByTraineeRequestHandler : IRequestHandler<GetEducationalInstitutionListByTraineeRequest, List<EducationalInstitutionDto>>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.EducationalInstitution> _EducationalInstitutionRepository;
        public GetEducationalInstitutionListByTraineeRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.EducationalInstitution> EducationalInstitutionRepository, IMapper mapper)
        {
            _EducationalInstitutionRepository = EducationalInstitutionRepository;
            _mapper = mapper;
        }
        public async Task<List<EducationalInstitutionDto>> Handle(GetEducationalInstitutionListByTraineeRequest request, CancellationToken cancellationToken)
        {
            var EducationalInstitution =  _EducationalInstitutionRepository.FilterWithInclude(x =>(x.TraineeId == request.Traineeid), "District", "Thana");
            return  _mapper.Map<List<EducationalInstitutionDto>>(EducationalInstitution);
        }
    }
}
