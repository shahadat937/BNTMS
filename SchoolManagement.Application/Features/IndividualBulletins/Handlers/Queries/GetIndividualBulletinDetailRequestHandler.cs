using AutoMapper;
using MediatR;
using SchoolManagement.Application.Contracts.Persistence;
using SchoolManagement.Application.DTOs.IndividualBulletin;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Queries
{
    public class GetIndividualBulletinDetailRequestHandler : IRequestHandler<GetIndividualBulletinDetailRequest, IndividualBulletinDto>
    {
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<IndividualBulletin> _IndividualBulletinRepository;
        public GetIndividualBulletinDetailRequestHandler(ISchoolManagementRepository<IndividualBulletin> IndividualBulletinRepository, IMapper mapper)
        {
            _IndividualBulletinRepository = IndividualBulletinRepository;
            _mapper = mapper;
        }
        public async Task<IndividualBulletinDto> Handle(GetIndividualBulletinDetailRequest request, CancellationToken cancellationToken)
        {
            var IndividualBulletin = await _IndividualBulletinRepository.Get(request.IndividualBulletinId);
            return _mapper.Map<IndividualBulletinDto>(IndividualBulletin);
        }
    }
}
