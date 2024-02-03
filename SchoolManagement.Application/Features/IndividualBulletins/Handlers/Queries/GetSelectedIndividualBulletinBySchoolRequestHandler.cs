using AutoMapper;
using SchoolManagement.Application.DTOs.IndividualBulletin;
using SchoolManagement.Application.Features.IndividualBulletins.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using SchoolManagement.Domain;

namespace SchoolManagement.Application.Features.IndividualBulletins.Handlers.Queries   
{
    public class GetSelectedIndividualBulletinBySchoolRequestHandler : IRequestHandler<GetSelectedIndividualBulletinBySchoolRequest, List<IndividualBulletinDto>>
    {

        private readonly ISchoolManagementRepository<IndividualBulletin> _IndividualBulletinRepository;

        private readonly IMapper _mapper;

        public GetSelectedIndividualBulletinBySchoolRequestHandler(ISchoolManagementRepository<IndividualBulletin> IndividualBulletinRepository, IMapper mapper)
        {
            _IndividualBulletinRepository = IndividualBulletinRepository;
            _mapper = mapper;
        }

        public async Task<List<IndividualBulletinDto>> Handle(GetSelectedIndividualBulletinBySchoolRequest request, CancellationToken cancellationToken)
        {
            IQueryable<IndividualBulletin> IndividualBulletins = _IndividualBulletinRepository.FilterWithInclude(x => x.BaseSchoolNameId == request.BaseSchoolNameId, "CourseName", "CourseDuration").OrderBy(x => x.Status);

            var IndividualBulletinDtos = _mapper.Map<List<IndividualBulletinDto>>(IndividualBulletins);

            return IndividualBulletinDtos;
        }
    }
}
