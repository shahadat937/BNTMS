using AutoMapper;
using SchoolManagement.Application.DTOs.Gender;
using SchoolManagement.Application.Features.Genders.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.Genders.Handlers.Queries
{
    public class GetGenderDetailRequestHandler : IRequestHandler<GetGenderDetailRequest, GenderDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.Gender> _GenderRepository;
        public GetGenderDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.Gender> GenderRepository, IMapper mapper)
        {
            _GenderRepository = GenderRepository;
            _mapper = mapper;
        }
        public async Task<GenderDto> Handle(GetGenderDetailRequest request, CancellationToken cancellationToken)
        {
            var Gender = await _GenderRepository.Get(request.GenderId);
            return _mapper.Map<GenderDto>(Gender);
        }
    }
}
