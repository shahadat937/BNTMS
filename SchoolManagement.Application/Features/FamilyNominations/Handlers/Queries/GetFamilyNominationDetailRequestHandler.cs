using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.FamilyNomination;
using SchoolManagement.Application.Features.FamilyNominations.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.FamilyNominations.Handlers.Queries
{
    public class GetFamilyNominationDetailRequestHandler : IRequestHandler<GetFamilyNominationDetailRequest, FamilyNominationDto>
    {
        private readonly IMapper _mapper;   
        private readonly ISchoolManagementRepository<FamilyNomination> _familyNominationRepository;       
        public GetFamilyNominationDetailRequestHandler(ISchoolManagementRepository<FamilyNomination> familyNominationRepository, IMapper mapper)
        {
            _familyNominationRepository = familyNominationRepository;    
            _mapper = mapper; 
        } 
        public async Task<FamilyNominationDto> Handle(GetFamilyNominationDetailRequest request, CancellationToken cancellationToken)
        {
            var familyNomination = await _familyNominationRepository.FindOneAsync(x => x.FamilyNominationId == request.Id);    
            return _mapper.Map<FamilyNominationDto>(familyNomination);    
        }
    }
}
