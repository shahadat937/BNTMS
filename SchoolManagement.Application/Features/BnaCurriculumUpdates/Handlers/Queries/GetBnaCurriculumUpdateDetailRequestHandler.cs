using AutoMapper;
using SchoolManagement.Application.DTOs.BnaCurriculumUpdate;
using SchoolManagement.Application.Features.BnaCurriculumUpdates.Requests.Queries;
using SchoolManagement.Application.Contracts.Persistence;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Features.BnaCurriculumUpdates.Handlers.Queries
{
    public class GetBnaCurriculumUpdateDetailRequestHandler : IRequestHandler<GetBnaCurriculumUpdateDetailRequest, BnaCurriculumUpdateDto>
    {
        // private readonly IUTOfficerTypeRepository _UTOfficerTypeRepository;
        private readonly IMapper _mapper;
        private readonly ISchoolManagementRepository<SchoolManagement.Domain.BnaCurriculumUpdate> _BnaCurriculumUpdateRepository;
        public GetBnaCurriculumUpdateDetailRequestHandler(ISchoolManagementRepository<SchoolManagement.Domain.BnaCurriculumUpdate> BnaCurriculumUpdateRepository, IMapper mapper)
        {
            _BnaCurriculumUpdateRepository = BnaCurriculumUpdateRepository;
            _mapper = mapper;
        }
        public async Task<BnaCurriculumUpdateDto> Handle(GetBnaCurriculumUpdateDetailRequest request, CancellationToken cancellationToken)
        {
            var BnaCurriculumUpdate = await _BnaCurriculumUpdateRepository.FindOneAsync(x => x.BnaCurriculumUpdateId == request.BnaCurriculumUpdateId);
            return _mapper.Map<BnaCurriculumUpdateDto>(BnaCurriculumUpdate);
        }
    }
}
